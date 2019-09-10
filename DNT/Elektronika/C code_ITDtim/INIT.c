#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/wdt.h>

/*
*INICJALIZACIJA SVIH PERIFERNIH JEDINICA(ATMEGA8_KNJIGOMAT)
*/
void ioinit(void)
{
	cli();//GASIM GLOBALNI INTERUPT
	
	DDRB|=_BV(DDB0);//ledica za blinkanje je OUTPUT da bolje svjetli
	DDRD|=_BV(DDD7);//OTVARANJE BRAVE
	DDRD|=_BV(DDD5);//ZVUÈNI SIGNAL
		
	/*
	* SETIRANJE EXTERNIH INTERUPTOVA
	* -svi interuptovi spojeni na njega ga spuštaju u nulu i još jedan pin tako da mikraè nakon
	* 	šta se dogodi interupt ide provjeriti koji je pin u nuli i po tome zakljuèuje koji je od interuptova se desio
	*/
	GICR |= _BV(INT1) | _BV(INT0);
	
	//PORTB|= _BV(PORTB1);	//PULL-UP DATA0
	//PORTB|= _BV(PORTB2);	//PULL-UP DATA1
	
	//PORTC|= _BV(PORTC5);	//PULL-UP PRISLONJENO
	//PORTC|= _BV(PORTC3);	//PULL-UP ZABRAVLJENO
	//PORTC|= _BV(PORTC2);	//PULL-UP VRATA UNUTRA
	//PORTC|= _BV(PORTC1);	//PULL-UP FOTO
	
	PORTD|=_BV(PORTD2);//PULL-UP INT0
	PORTD|=_BV(PORTD3);//PULL-UP INT1
	
	MCUCR|=_BV(ISC11) | _BV(ISC01);//FALLING EDGE OBA INTRUPTA

	
	/*
	* SETIRANJE UART-A(MIKROKONTROLER RADI NA 16.000 MHz)
	*/	
	UBRRL = 0x33; //Baud rate: 19200, Parity: None, Data bits: 8, Stop bits: 1
	UCSRB = _BV(TXEN) | _BV(RXEN) | _BV(RXCIE); /* tx/rx enable , INTERUPT RECIVE*/
	UCSRC |= _BV(URSEL) | _BV(UCSZ0) | _BV(UCSZ1);// | _BV(UPM0)| _BV(UPM1);//palim odd parity bit, 8 data bit
	
	/*
	* SETIRANJE TIMER0(ENABLE INTERUPT)
	*/
	TIMSK|= _BV(TOIE0);//INTERUPT ENABLE(INTRUPT SE DOGODI KAD DOÐE DO OVERFLOWA)
	
	sei();//PALIM GLOBALNI INTERUPT

  /*
   * Enable the watchdog with the largest prescaler.  Will cause a
   * watchdog reset after approximately 2 s @ Vcc = 5 V
   */
	wdt_enable(WDTO_2S);

}

