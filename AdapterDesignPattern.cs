using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    //  class adapter

    // Target Interface
    public interface IMediaPlayer
    {
        void Play(string audioType, string fileName);
    }

    // Adaptee - Plays only mp3 files
    public class MP3Player
    {
        public void PlayMP3(string fileName)
        {
            Console.WriteLine("Playing MP3: " + fileName);
        }
    }

    // Adapter - Adapting MP3Player to IMediaPlayer interface
    public class MediaAdapter : IMediaPlayer
    {
        private MP3Player mp3Player = new MP3Player();

        public void Play(string audioType, string fileName)
        {
            if (audioType.Equals("mp3", StringComparison.OrdinalIgnoreCase))
            {
                mp3Player.PlayMP3(fileName);
            }
            else
            {
                Console.WriteLine("Invalid media type. Only MP3 is supported.");
            }
        }
    }

    // *************************************** EXAMPLE  02
    // object adapter

    // The third-party PaymentProcessor class
    public class PaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"You have paid {amount:C}.");
        }
    }

    // your application's IPaymentProvider interface
    public interface IPaymentProvider
    {
        void MakePayment(string details, decimal amount);
    }

    // The adapter class that adapts the PaymentProcessor
    // to the IPaymentProvider interface
    public class PaymentProviderAdapter : IPaymentProvider
    {
        private readonly PaymentProcessor _paymentProcessor;

        public PaymentProviderAdapter(PaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void MakePayment(string details, decimal amount)
        {
            Console.WriteLine($"Making a payment for: {details}");
            _paymentProcessor.ProcessPayment(amount);
        }
    }
}
