using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************
    // Mediator interface
    interface IChatRoom
    {
        void SendMessage(User user, string message);
    }

    // Concrete mediator class
    class ChatRoom : IChatRoom
    {
        private readonly Dictionary<User, string> users = new Dictionary<User, string>();

        public void RegisterUser(User user)
        {
            users[user] = user.Name;
        }

        public void SendMessage(User user, string message)
        {
            foreach (var u in users.Keys)
            {
                if (u != user) // Exclude the sender
                {
                    u.ReceiveMessage(user, message);
                }
            }
        }
    }

    // Colleague class
    class User
    {
        public string Name { get; }
        private readonly IChatRoom chatRoom;

        public User(string name, IChatRoom chatRoom)
        {
            Name = name;
            this.chatRoom = chatRoom;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            chatRoom.SendMessage(this, message);
        }

        public void ReceiveMessage(User sender, string message)
        {
            Console.WriteLine($"{Name} received a message from {sender.Name}: {message}");
        }
    }
}


// ****************************************  Example 02 *******************************************

// Mediator interface
interface IAirTrafficControl
{
    void RegisterFlight(Flight flight);
    void SendMessage(Flight flight, string message);
}

// Concrete mediator class
class AirTrafficControl : IAirTrafficControl
{
    private readonly Dictionary<Flight, string> flights = new Dictionary<Flight, string>();

    public void RegisterFlight(Flight flight)
    {
        flights[flight] = flight.FlightNumber;
    }

    public void SendMessage(Flight flight, string message)
    {
        foreach (var f in flights.Keys)
        {
            if (f != flight) // Exclude the sender
            {
                f.ReceiveMessage(flight, message);
            }
        }
    }
}

// Colleague class
class Flight
{
    public string FlightNumber { get; }
    private readonly IAirTrafficControl atc;

    public Flight(string flightNumber, IAirTrafficControl atc)
    {
        FlightNumber = flightNumber;
        this.atc = atc;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"Flight {FlightNumber} sends: {message}");
        atc.SendMessage(this, message);
    }

    public void ReceiveMessage(Flight sender, string message)
    {
        Console.WriteLine($"Flight {FlightNumber} received a message from Flight {sender.FlightNumber}: {message}");
    }
}
