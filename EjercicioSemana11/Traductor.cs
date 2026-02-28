using System;
using System.Collections.Generic;

namespace TraductorDiccionario
{
    // Clase que maneja el diccionario y la lógica de traducción
    public class Traductor
    {
        // Diccionario privado para almacenar palabras Español -> Inglés
        private Dictionary<string, string> _diccionario;

        // Constructor: inicializa el diccionario con palabras base
        public Traductor()
        {
            _diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"tiempo", "time"},
                {"persona", "person"},
                {"año", "year"},
                {"camino", "way"},
                {"forma", "way"},
                {"día", "day"},
                {"cosa", "thing"},
                {"hombre", "man"},
                {"mundo", "world"},
                {"vida", "life"},
                {"mano", "hand"},
                {"parte", "part"},
                {"niño", "child"},
                {"niña", "child"},
                {"ojo", "eye"},
                {"mujer", "woman"},
                {"lugar", "place"},
                {"trabajo", "work"},
                {"semana", "week"},
                {"caso", "case"},
                {"punto", "point"},
                {"tema", "point"},
                {"gobierno", "government"},
                {"empresa", "company"},
                {"compañía", "company"}
            };
        }

        // Método que traduce una frase completa
        public string Traducir(string fraseOriginal)
        {
            // Separamos la frase por espacios
            string[] palabras = fraseOriginal.Split(' ');

            for (int i = 0; i < palabras.Length; i++)
            {
                string palabraActual = palabras[i];
                string signoFinal = "";

                // Verificamos si termina con signo de puntuación
                if (palabraActual.Length > 0)
                {
                    char ultimoCaracter = palabraActual[palabraActual.Length - 1];

                    if (ultimoCaracter == '.' ||
                        ultimoCaracter == ',' ||
                        ultimoCaracter == ';' ||
                        ultimoCaracter == ':')
                    {
                        signoFinal = ultimoCaracter.ToString();
                        palabraActual = palabraActual.Substring(0, palabraActual.Length - 1);
                    }
                }

                string palabraLimpia = palabraActual.ToLower();

                // Si la palabra existe en el diccionario, la traducimos
                if (_diccionario.ContainsKey(palabraLimpia))
                {
                    palabras[i] = _diccionario[palabraLimpia] + signoFinal;
                }
                else
                {
                    // Si no existe, se deja igual
                    palabras[i] = palabraActual + signoFinal;
                }
            }

            // Unimos nuevamente la frase traducida
            return string.Join(" ", palabras);
        }

        // Método para agregar nuevas palabras con validación
        public bool IntentarAgregarPalabra(string espanol, string ingles)
        {
            if (string.IsNullOrWhiteSpace(espanol) || string.IsNullOrWhiteSpace(ingles))
            {
                return false;
            }

            espanol = espanol.Trim().ToLower();
            ingles = ingles.Trim().ToLower();

            if (_diccionario.ContainsKey(espanol))
            {
                return false;
            }

            _diccionario.Add(espanol, ingles);
            return true;
        }

        // Método para consultar traducción existente
        public string ObtenerTraduccionDe(string espanol)
        {
            if (string.IsNullOrWhiteSpace(espanol))
                return null;

            espanol = espanol.ToLower();

            if (_diccionario.ContainsKey(espanol))
            {
                return _diccionario[espanol];
            }

            return null;
        }
    }
}