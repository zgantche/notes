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
 
    // The CarStereo nice speakers, but requires an input station/channel to play
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
        // Snoop Dog, only knows how to use car stereos
        private static void snoopDog(ICarStereo stereo, string jamz = null){
            Console.WriteLine(stereo.PlayStereoSpeakers(jamz));
        }
 
        static void Main(string[] args)
        {
            Console.WriteLine("--=[BEGIN]=--\n");
            
            var carStereo = new CarStereo();
            var phone = new Phone("♫♫ mp3 audio ♫♫");
            var androidPhone = new Phone("other mp3");
            // Console.WriteLine(phone.PlayPhoneSpeakers());
 
            Console.WriteLine("snoopDog: I can play music just fine with CarStereo objects.");
            snoopDog(carStereo);
            snoopDog(carStereo, "♫ 88.1 FM Radio ♫");
 
            Console.WriteLine("\nsnoopDog: The Phone object is neat, it's got nice jamz.");
            Console.WriteLine("BUT that ain't no CarStereo. Sorry cuz.");
            // snoopDog(phone);
 
            Console.WriteLine("\nsnoopDog: However, with this Adapter, it sure *looks* like a CarStereo.");
            var adapter = new Adapter(phone);
            snoopDog(adapter);
 
            Console.WriteLine("\n--==[END]==--");
        }
    }
}