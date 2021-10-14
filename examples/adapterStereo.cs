using System;
 
namespace Adapter
{
    // The CarStereo interface defines a method which expects a music channel to play
    public interface ICarStereo
    {
        string PlayStereoSpeakers(string musicChannel);
    }
 
    // The Phone interface has its own, local music. Along with a method to play it (why not?)
    public interface IPhone
    {
 
        string Music { get; set; }
 
        string PlayPhoneSpeakers();
    }
 
    // The CarStereo has nice speakers
    class CarStereo : ICarStereo
    {
        public string PlayStereoSpeakers(string musicChannel)
        {
            if (musicChannel == null)
            {
                musicChannel = "***static***";
            }
 
            return "CAR STEREO goes: " + musicChannel;
        }
    }
 
    // The Phone contains some useful behavior-- we got our own music!-- but its interface is incompatible with the CarStereo's
    class Phone : IPhone
    {
        public Phone(string music)
        {
            this.Music = music;
        }
        public string Music { get; set; }
        public string PlayPhoneSpeakers()
        {
            return "Phone speakers go: " + Music;
        }
    }
 
    // The Adapter makes the Phone's interface compatible with the CarStereo's interface (hooray!)
    class Adapter : ICarStereo
    {
        private readonly Phone _phone;
 
        public Adapter(Phone phone)
        {
            _phone = phone;
        }
 
        public string PlayStereoSpeakers(string musicChannel)
        {
            return "CAR STEREO goes: " + _phone.Music;
        }
    }
 
    class Program
    {
        // Snoop Dog, just wants to listen to some jamz in his car
        private static void snoopDog(ICarStereo stereo, string jamz = null){
            Console.WriteLine(stereo.PlayStereoSpeakers(jamz));
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("--=[BEGIN]=--\n");
                
                var carStereo = new CarStereo();
                var phone = new Phone("♫♫ mp3 audio ♫♫");
 
                Console.WriteLine("snoopDog: I can play music just fine with CarStereo objects.");
                snoopDog(carStereo);
                snoopDog(carStereo, "♫ 88.1 FM Radio ♫");
 
                Console.WriteLine("\nsnoopDog: The Phone class is neat, it plays it's own music.");
                Console.WriteLine(phone.PlayPhoneSpeakers());
                Console.WriteLine("But it has a weird interface. I can't play that on the car stereo.");
                // snoopDog(phone);
 
                Console.WriteLine("\nsnoopDog: However, let's see if it works if I connect the Phone to this Adapter:");
                var adapter = new Adapter(phone);
                snoopDog(adapter);
 
                Console.WriteLine("\n--==[END]==--");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}