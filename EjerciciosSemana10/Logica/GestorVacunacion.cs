using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVacunacionCovid.Entidades;

namespace SistemaVacunacionCovid.Logica
{
    public class GestorVacunacion
    {
        private static Random generadorAleatorio = new Random();

        public HashSet<RegistroCiudadano> PadronNacional { get; }
        public HashSet<RegistroCiudadano> VacunadosPfizer { get; }
        public HashSet<RegistroCiudadano> VacunadosAstraZeneca { get; }

        public GestorVacunacion(int totalCiudadanos)
        {
            PadronNacional = GenerarPadron(totalCiudadanos);
            VacunadosPfizer = SeleccionarSubconjunto(75);
            VacunadosAstraZeneca = SeleccionarSubconjunto(75);
        }

        private HashSet<RegistroCiudadano> GenerarPadron(int cantidad)
        {
            HashSet<RegistroCiudadano> ciudadanos = new HashSet<RegistroCiudadano>();

            for (int i = 1; i <= cantidad; i++)
            {
                ciudadanos.Add(new RegistroCiudadano("Ciudadano_" + i));
            }

            return ciudadanos;
        }

        private HashSet<RegistroCiudadano> SeleccionarSubconjunto(int cantidad)
        {
            HashSet<RegistroCiudadano> seleccionados = new HashSet<RegistroCiudadano>();
            List<RegistroCiudadano> lista = PadronNacional.ToList();

            while (seleccionados.Count < cantidad)
            {
                int indice = generadorAleatorio.Next(lista.Count);
                seleccionados.Add(lista[indice]);
            }

            return seleccionados;
        }

        // U − (P ∪ A)
        public HashSet<RegistroCiudadano> ObtenerNoVacunados()
        {
            HashSet<RegistroCiudadano> union = new HashSet<RegistroCiudadano>(VacunadosPfizer);
            union.UnionWith(VacunadosAstraZeneca);

            HashSet<RegistroCiudadano> resultado = new HashSet<RegistroCiudadano>(PadronNacional);
            resultado.ExceptWith(union);

            return resultado;
        }

        // P ∩ A
        public HashSet<RegistroCiudadano> ObtenerAmbasDosis()
        {
            HashSet<RegistroCiudadano> interseccion = new HashSet<RegistroCiudadano>(VacunadosPfizer);
            interseccion.IntersectWith(VacunadosAstraZeneca);

            return interseccion;
        }

        // P − A
        public HashSet<RegistroCiudadano> ObtenerSoloPfizer()
        {
            HashSet<RegistroCiudadano> resultado = new HashSet<RegistroCiudadano>(VacunadosPfizer);
            resultado.ExceptWith(VacunadosAstraZeneca);
            return resultado;
        }

        // A − P
        public HashSet<RegistroCiudadano> ObtenerSoloAstraZeneca()
        {
            HashSet<RegistroCiudadano> resultado = new HashSet<RegistroCiudadano>(VacunadosAstraZeneca);
            resultado.ExceptWith(VacunadosPfizer);
            return resultado;
        }
    }
}