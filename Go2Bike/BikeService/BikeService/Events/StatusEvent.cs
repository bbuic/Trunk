using System;
using BikeService.Events.EventHandlers;

namespace BikeService.Events
{
    public enum StatusLogType:short
    {
        BikeRemovedNormal = 0,
        SwithLocked = 1,
        Maintenance = 2,
        VandalismSwitch1Tag0 = 3,
        TagLost = 4,
        VandalismSwitch0Tag1 = 5,
        SwitchLost = 6,
        EmergencyAssignmentFromCan = 7,
        EmergencyAssignment = 8,
        BikeStealing = 9,
        Unknow10 = 10,
        Unknow11 = 11,
        DeniedWrongCardDate = 12,
        DeniedWrongCrc = 13,
        DeniedWrongBlackList = 14,
        DeniedByServerNotAck = 15,
        DenialForNormalUserOutsideOfSchedule = 16,
        WithoutServerDeniedWrongCardDate = 17,
        DenialTypeOfUser = 18,
        Unknow19 = 19,
        Unknow20 = 20,
        Unknow21 = 21,
        BikeRemovedMaintenance = 22,
        ProblemWithMotor = 23,
        WithoutServerDenied = 24

    }

    public class StatusEvent: AbstractEvent
    {
        public StatusLogType StatusLogType { get; set; }
        public int RfidTag { get; set; }
        public int BikeTag { get; set; }

        internal override void Handle()
        {
            StatusLogType = (StatusLogType) Messages[1][2];
            RfidTag = BitConverter.ToInt16(new[]{ Messages[1][3] , Messages[1][4] , Messages[1][5], Messages[1][6], Messages[2][2], Messages[2][3] }, 0);
            BikeTag = BitConverter.ToInt16(new[]{ Messages[1][3] , Messages[1][4] , Messages[1][5], Messages[1][6], Messages[2][2], Messages[2][3] }, 0);
        }
    }
}
