using System;

namespace SistemaVacunacionCovid.Entidades
{
    public class RegistroCiudadano
    {
        public string Identificador { get; }

        public RegistroCiudadano(string identificador)
        {
            Identificador = identificador;
        }

        public override string ToString()
        {
            return Identificador;
        }

        public override bool Equals(object obj)
        {
            if (obj is RegistroCiudadano otro)
            {
                return Identificador == otro.Identificador;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Identificador.GetHashCode();
        }
    }
}