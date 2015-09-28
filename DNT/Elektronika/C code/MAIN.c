#include <util/delay.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/wdt.h>


extern void ioinit(void);
static void putchr(char c);
volatile unsigned short scaler=0x3D4;

unsigned char BROJ_KARTICE_1=0; //broj INDALA kartice u koju se upisuje wiegand protokolom
unsigned char BROJ_KARTICE=0;
int	INDALA_BB=27;//broj bitova na indala kartici

void timer0_start(void){scaler=0x3D4;TCNT0=0x00;TCCR0 |= _BV(CS00);}//PLAIM TIMER0(NO PRESCALING)
void timer0_stop(void){TCCR0 &= ~_BV(CS00);}//GASIM TIMER0(NO PRESCALING)

void OTVORI_BRAVU(void){PORTD |= _BV(PORTD7);}
void ZATVORI_BRAVU(void){PORTD &= ~_BV(PORTD7);}
void BEEP(void){PORTD |= _BV(PORTD5);_delay_loop_2(65500);PORTD &= ~_BV(PORTD5);}

//!!!!!!!!!!! VREMENSKA ODGODA za fotoceliju u KANALU !!!!!!!!!!!!!!!!
static void delay_foto(void)
{
  uint8_t i;

  for (i = 0; i < 100; i++)
  {
    wdt_reset();//RESETIRANJE WATCHDOG-A
	_delay_ms(15);
  }
}
//!!!!!!!!!!!OBRADA INTERUPTA KOJI PROUZROCI OWERFOLOV TIMER-A 0!!!!!!!!!!!!!!!!
ISR(TIMER0_OVF_vect)
{
	if (--scaler == 0)
    {
	timer0_stop();INDALA_BB=27;BROJ_KARTICE=0;BROJ_KARTICE_1=0;
	scaler=0x3D4;	
	}
}
//!!!!!!!!!!!FLAGS!!!!!!!!!!!!!!!!
volatile struct
{
  uint8_t int0: 1;
  uint8_t int_rx: 1;
  uint8_t vrata_otvorena: 1;//flag koji obilježava dali su varat otvorea ili zatvorena (vrata_otvorena==true; ==> OTVORENA VRATA)
  uint8_t fotocelija: 1;//ovime obilježavam da je nešto na fotoèeliji
 // uint8_t vrata_unutra: 1;//ovime se prati dali su unutrašnja vrata otvorena
  uint8_t vrata_zatvori: 1;//obilježava da bi trebalo zatvoriti vanjska vrata jer su bila otvorena dulje od 30sek. (zvuèni signal)
  uint8_t vrata_kartica: 1;//bit koji pokazuje da je raèunalo naredilo da se otvore vrata
}
flag;
//!!!!!!!!!!!SLANJE BAYTA NA SERIJSKI PORT!!!!!!!!!!!!!!!!!!!!!!!!!!!!
static void putchr(char c)
{
  loop_until_bit_is_set(UCSRA, UDRE);
  UDR = c;
}

//!!!!!!!!!!!OBRADA INTERUPTA RECIVE SERIJSKOG PORTA!!!!!!!!!!!!!!!!!!!!!!!!!!!!
volatile char pod_uart;
ISR(USART_RXC_vect)
{
	if (bit_is_set(UCSRA, FE)){putchr(0xAA);pod_uart= UDR;goto van;}//frame greska
	if(bit_is_set(UCSRA, PE)){putchr(0xBB);pod_uart= UDR;goto van;}//parity greska
	if(bit_is_set(UCSRA, DOR)){putchr(0xCC);pod_uart= UDR;goto van;}//citanje greska
   	pod_uart= UDR;
  	flag.int_rx = 1;

	van:;
}
//!!!!!!!!!!!OBRADA INTERUPTA 0-1(wiegand)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
ISR(INT1_vect)
{
  /*DATA1*/
	timer0_start();
	INDALA_BB--;
	if(INDALA_BB<=13){BROJ_KARTICE<<=1;BROJ_KARTICE|=0x1;if(INDALA_BB==8){BROJ_KARTICE_1=BROJ_KARTICE;BROJ_KARTICE=0;}}
	if(INDALA_BB==0){timer0_stop();putchr(0x20);putchr(BROJ_KARTICE_1);putchr(BROJ_KARTICE);INDALA_BB=27;BROJ_KARTICE=0;BROJ_KARTICE_1=0;/*putchr(0xD);*/}
}
ISR(INT0_vect)
{
	  /*DATA0*/
	timer0_start();
	INDALA_BB--;
	if(INDALA_BB<=13){BROJ_KARTICE<<=1;BROJ_KARTICE&=0xFFFE;if(INDALA_BB==8){BROJ_KARTICE_1=BROJ_KARTICE;BROJ_KARTICE=0;}}
	if(INDALA_BB==0){timer0_stop();putchr(0x20);putchr(BROJ_KARTICE_1);putchr(BROJ_KARTICE);INDALA_BB=27;BROJ_KARTICE=0;BROJ_KARTICE_1=0;/*putchr(0xD);*/}
}
//!!!!!!!!!!!!MAIN PETLJA(KNJIGOMAT)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
int main(void)
{
	ioinit();//INICJALIZACIJA SUSTAVA
	unsigned int kont_led=0;
//	flag.vrata_unutra=1;//INICJALIZIRAJ DA SU VRATA ZATVORENA
	flag.fotocelija=0;
	flag.vrata_otvorena=0;
	INDALA_BB=27;
	
	for (;;)
	{
		 wdt_reset();//RESETIRANJE WATCHDOG-A(koji se dogaða svakih 2 sekunde)
		
		/***********************************************************************************************
		*FUNKCIJA KOJA PRATI PRISLONJENOST VRATI
		
		if(bit_is_set(PINC,PINC5) && flag.vrata_otvorena==0)//VRATA OTVORENA
		{
			flag.vrata_otvorena=1;
			
			if(flag.vrata_kartica==1){putchr(0x21);}
			OTVORI_BRAVU();
			_delay_ms(100);
		}
		
		//------------------------------------------------------------------------------------
		
		if(bit_is_clear(PINC,PINC5) && flag.vrata_otvorena==1)//VRATA ZATVORENA
		{
			flag.vrata_otvorena=0;
			
			flag.vrata_zatvori=0;//bit koji obilježava dali je postojao alarm otvorena vrata
			ZATVORI_BRAVU();
			if(flag.vrata_kartica==1){putchr(0x22);}flag.vrata_kartica=0;
			_delay_ms(100);
					
		}
		//************************************************************************************************
*/

		//OTVORI ako vrata nisu prislonjena i zasun je vani
		if(bit_is_set(PINC,PINC5) && bit_is_clear(PINC,PINC3)){
			OTVORI_BRAVU();			
		}
		
		//ZATVORI ako su vrata prislonjena i zasun je uvuèen
		if(bit_is_clear(PINC,PINC5) && bit_is_set(PINC,PINC3) && flag.vrata_otvorena==1){
			ZATVORI_BRAVU();
		}
		
		//Vrata su ZATVORENA ako su prislonjena i zasun je vani
		if(bit_is_clear(PINC,PINC5) && bit_is_clear(PINC,PINC3) && flag.vrata_otvorena==1){			
			
			if(flag.vrata_kartica==1){
				putchr(0x22);
			}
			
			flag.vrata_kartica = 0;
			flag.vrata_zatvori = 0;//bit koji obilježava da li je postojao alarm otvorena vrata
			flag.vrata_otvorena = 0;
		}
		
		//Vrata su OTVORENA ako nisu prislonjena i zasnun je uvuèen
		if(bit_is_set(PINC,PINC5) && bit_is_set(PINC,PINC3) && flag.vrata_otvorena==0){
			if(flag.vrata_kartica==1){
				putchr(0x21);
			}
			flag.vrata_otvorena = 1;
		}



		/*************************************************************************************************
		*FUNKCIJA KOJA PRATI FOTOCELIJU
		*/
		if(bit_is_clear(PINC,PINC1) && flag.fotocelija==0)
		{
			flag.fotocelija=1;
			
			flag.vrata_zatvori=0;//bit koji obilježava dali je postojao alarm otvorena vrata
			
			if(flag.vrata_kartica==1){putchr(0x23);}//AO SU VRATA OTVORENA KARTICOM
			delay_foto();
			if(bit_is_set(PINC,PINC1)){flag.fotocelija=0;}else{putchr(0x24);BEEP();}
			
			
		}//NESTO NA FOTOCELIJI(prvi doticaj sa vreèicom)
		
		if(bit_is_set(PINC,PINC1) && flag.fotocelija==1){flag.fotocelija=0;putchr(0x27);}//maklo se sa fotoèelije(u sluèaju alarma)
		//********************************************************************************************************
  
		  
		  /*
	       * NA UART JE PRISTIGAO PODATAK I PREMA TOME SE PONAŠAM
	       */
		  if (flag.int_rx==1)
		  {
			  flag.int_rx = 0;
			  

			  if(pod_uart==0x10)
			  {
				OTVORI_BRAVU();flag.vrata_kartica=1;
			  }
			  
			  /*
			   */
			  if(pod_uart==0x11)
			  {
				ZATVORI_BRAVU();flag.vrata_kartica=0;
			  }//OVDJE RAÈUNALO ZATVORI VRATA AKO KORISNIK NIJE U TRI(3 sek) OTVORIO VRATA
			  
			  /*
			   * obilježavam da su vanjska vrata predugo otvorena (ALARM OTVORENA VRATA -ZVUÈNI SIGNAL)
			   */
			  if(pod_uart==0x12){flag.vrata_zatvori=1;}
			  
			  pod_uart=0x00;

		  }

		  /*
	       * KONTROLNA LEDICA
	       */
		  if (++kont_led==15500)
		  {
			kont_led=0;
			if(flag.vrata_zatvori==1){BEEP();}
			PORTB ^= _BV(PORTB0);//blinkanje sa ledicom na mikraèu
		  } 
		 
	}
}
