namespace Esercizioo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> studenti = new List<string>();
            List<double> voti = new List<double>();

            string scelta = "";

            
            while (scelta != "4")
            {
                Console.WriteLine("    GESTIONALE REGISTRO STUDENTI    ");
                Console.WriteLine("1. Inserisci Studente");
                Console.WriteLine("2. Stampa Riepilogo");
                Console.WriteLine("3. Salva su File");
                Console.WriteLine("4. Esci");
                Console.Write("Scegli un'opzione (1-4): ");

                scelta = Console.ReadLine();

                if (scelta == "1")
                {
                    InserisciStudente(studenti, voti);
                }
                else if (scelta == "2")
                {
                    Riepilogo(studenti, voti);
                }
                else if (scelta == "3")
                {
                    SalvaSuFile(studenti, voti);
                }
                else if (scelta == "4")
                {
                    Console.WriteLine("Sei uscito dal programma");
                }
                else
                {
                    Console.WriteLine("Opzione non valida! Riprova.");
                }
            }
        }

        static void InserisciStudente(List<string> studenti, List<double> voti)
        {
            Console.Write("Inserisci il nome dello studente: ");
            string nomestudente = Console.ReadLine();

            nomestudente = PuliziaTesto(nomestudente);
            Console.WriteLine("Studente: " + nomestudente );

            Console.Write("Inserisci Voto (2.0 - 10.0): ");
            string inputVoto = Console.ReadLine();

            inputVoto = inputVoto.Replace('.', ',');

            double voto = Convert.ToDouble(inputVoto);

            while (VotoVero(voto) == false)
            {
                Console.WriteLine("Voto non valido! Deve essere compreso tra 2.0 e 10.0.");
                Console.Write("Inserisci un Voto (2.0 - 10.0):");

                string nuovoInputVoto = Console.ReadLine();
                nuovoInputVoto = nuovoInputVoto.Replace('.', ',');
                voto = Convert.ToDouble(nuovoInputVoto);
            }

            studenti.Add(nomestudente);
            voti.Add(voto);

            Console.WriteLine("Studente aggiunto con successo");
        }

        static string PuliziaTesto(string testo)
        {
            testo = testo.Trim();

            string primaLettera = testo.Substring(0, 1).ToUpper();
            string restoTesto = testo.Substring(1).ToLower();

            string testoFinale = primaLettera + restoTesto;

            return testoFinale;
        }

        static bool VotoVero(double voto)
        {
            if (voto >= 2.0 && voto <= 10.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Riepilogo(List<string> studenti, List<double> voti)
        {
            if (studenti.Count == 0)
            {
                Console.WriteLine("Nessun studente presente");
            }
            else
            {
                Console.WriteLine("    RIEPILOGO STUDENTI    ");

                double sommaVoti = 0;

                for (int i = 0; i < studenti.Count; i++)
                {
                    Console.WriteLine( studenti[i] + "  Voto: " + voti[i]);
                    sommaVoti = sommaVoti + voti[i];
                }

                double media = sommaVoti / studenti.Count;
                Console.WriteLine("Media generale della classe: " + media);
            }
        }

        static void SalvaSuFile(List<string> studenti, List<double> voti)
        {
            if (studenti.Count == 0)
            {
                Console.WriteLine("Non è presente nulla da salvare");
            }
            else
            {
                for (int i = 0; i < studenti.Count; i++)
                {
                    string riga = studenti[i] + "," + voti[i] + "\n";
                    File.AppendAllText("registro.txt", riga);
                }

                Console.WriteLine("Dati salvati in registro.txt");
            }
        }
    }
}
