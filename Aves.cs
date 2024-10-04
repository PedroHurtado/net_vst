/*
  En el mundo de las aves hay pinpuinos que pesan 5 kg y aguilas
  que pesan 10 kg y vuelan a 100 km/hora
  
*/

namespace Aves{
    public abstract class Ave{
        public int Peso {get;init;}
        protected Ave(int peso){
            Peso = peso;
        }    }

    public abstract class AveVoladora:Ave{
        public int Velocidad {get;init;}
        protected AveVoladora(int peso,int velocidad):base(peso){
            Velocidad = velocidad;
        }
    }

    public abstract class AveNoVoladora : Ave
    {
        protected AveNoVoladora(int peso) : base(peso)
        {
        }
    }

    public class Aguila : AveVoladora
    {
        public Aguila(int peso, int velocidad) : base(peso, velocidad)
        {
        }
    }
    public class Pinguino : AveNoVoladora
    {
        public Pinguino(int peso) : base(peso)
        {
        }
    }
    public class Paloma : AveVoladora
    {
        public Paloma(int peso, int velocidad) : base(peso, velocidad)
        {
        }
    }

    public static class Printer{
        public static void PrintAve(Ave ave){

        }
        public static void PrintAveVoladora(AveVoladora ave){

        }

        public static void PrintAveNoVoladora(AveNoVoladora ave){

        }
    }
}