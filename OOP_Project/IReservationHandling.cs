namespace OOP_Project
{
    public interface IReservationHandling
    {
        bool ApproveRequest(int reservationId);
        bool DeclineRequest(int reservationId);
    }
}