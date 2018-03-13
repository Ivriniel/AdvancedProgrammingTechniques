using MojaBiblioteczka.Model;
using MojaBiblioteczka.Repository;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MojaBiblioteczka.ViewModel
{
    class BiblioteczkaViewModel : BindableBase
    {
        IKsiazkaRepository ksiazkaRepositoryEF;
        IKsiazkaRepository ksiazkaRepositoryXML;

        IRozdzialRepository rozdzialRepositoryEF;
        IRozdzialRepository rozdzialRepositoryXML;

        #region Property

        private double wybranaOcenaEF=0.0;
        public double WybranaOcenaEF
        {
            get { return wybranaOcenaEF; }
            set { if(Double.TryParse(value.ToString(), out wybranaOcenaEF) && value <= 5 && value >= 0)
                    SetProperty(ref wybranaOcenaEF, value); }
        }

        private ObservableCollection<Ksiazka> wszystkieKsiazkiEF;
        public ObservableCollection<Ksiazka> WszystkieKsiazkiEF
        {
            get { return wszystkieKsiazkiEF; }
            set { SetProperty(ref wszystkieKsiazkiEF, value); }
        }

        private ObservableCollection<Rozdzial> wszystkieRozdzialy;
        public ObservableCollection<Rozdzial> WszystkieRozdzialy
        {
            get { return wszystkieRozdzialy; }
            set { SetProperty(ref wszystkieRozdzialy, value); }
        }

        private ObservableCollection<Ksiazka> listaKsiazekEF;
        public ObservableCollection<Ksiazka> ListaKsiazekEF
        {
            get { return listaKsiazekEF; }
            set { SetProperty(ref listaKsiazekEF, value); }
        }

        private ObservableCollection<Ksiazka> listaKsiazekXML;
        public ObservableCollection<Ksiazka> ListaKsiazekXML
        {
            get { return listaKsiazekXML; }
            set { SetProperty(ref listaKsiazekXML, value); }
        }

        private int usuwaneIDEF = 0;
        public int UsuwaneIDEF
        {
            get { return usuwaneIDEF; }
            set
            {
                if (Int32.TryParse(value.ToString(), out usuwaneIDEF))
                    SetProperty(ref usuwaneIDEF, value);
            }
        }

        private int wybraneIDEF = 0;
        public int WybraneIDEF
        {
            get { return wybraneIDEF; }
            set
            {
                if (Int32.TryParse(value.ToString(), out wybraneIDEF))
                    SetProperty(ref wybraneIDEF, value);
            }
        }

        private double nowaOcenaEF = 0.0;
        public double NowaOcenaEF
        {
            get { return nowaOcenaEF; }
            set
            {
                if (Double.TryParse(value.ToString(), out nowaOcenaEF) && value <= 5 && value >= 0)
                    SetProperty(ref nowaOcenaEF, value);
            }
        }


        private string nowyTytul;
        public string NowyTytul
        {
            get { return nowyTytul; }
            set
            {
                if (value.ToString().Length>0) SetProperty(ref nowyTytul, value);
            }
        }

        private string nowyAutorImie;
        public string NowyAutorImie
        {
            get { return nowyAutorImie; }
            set
            {
                if (value.ToString().Length > 0) SetProperty(ref nowyAutorImie, value);
            }
        }

        private string nowyAutorNazwisko;
        public string NowyAutorNazwisko
        {
            get { return nowyAutorNazwisko; }
            set
            {
                if (value.ToString().Length > 0) SetProperty(ref nowyAutorNazwisko, value);
            }
        }

        private double nowaKsiazkaOcena = 0.0;
        public double NowaKsiazkaOcena
        {
            get { return nowaKsiazkaOcena; }
            set
            {
                if (Double.TryParse(value.ToString(), out nowaKsiazkaOcena) && value<=5 && value>=0)
                    SetProperty(ref nowaKsiazkaOcena, value);
            }
        }

        private int usuwaneIDXML = 0;
        public int UsuwaneIDXML
        {
            get { return usuwaneIDXML; }
            set
            {
                if (Int32.TryParse(value.ToString(), out usuwaneIDXML))
                    SetProperty(ref usuwaneIDXML, value);
            }
        }

        private int wybraneIDXML = 0;
        public int WybraneIDXML
        {
            get { return wybraneIDXML; }
            set
            {
                if (Int32.TryParse(value.ToString(), out wybraneIDXML))
                    SetProperty(ref wybraneIDXML, value);
            }
        }

        private double nowaOcenaXML = 0.0;
        public double NowaOcenaXML
        {
            get { return nowaOcenaXML; }
            set
            {
                if (Double.TryParse(value.ToString(), out nowaOcenaXML) && value <= 5 && value >= 0)
                    SetProperty(ref nowaOcenaXML, value);
            }
        }

        private double wybranaOcenaXML = 0.0;
        public double WybranaOcenaXML
        {
            get { return wybranaOcenaXML; }
            set
            {
                if (Double.TryParse(value.ToString(), out wybranaOcenaXML) && value <= 5 && value >= 0)
                    SetProperty(ref wybranaOcenaXML, value);
            }
        }

        private Ksiazka wybranaKsiazka;
        public Ksiazka WybranaKsiazkaEF
        {
            get { return wybranaKsiazka; }
            set
            {
                SetProperty(ref wybranaKsiazka, value);
                WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll().Where(r=>(r.IdKsiazka==wybranaKsiazka.Id)));
            }
        }

        private Ksiazka wybranaKsiazkaXML;
        public Ksiazka WybranaKsiazkaXML
        {
            get { return wybranaKsiazkaXML; }
            set
            {
                try
                {
                    SetProperty(ref wybranaKsiazkaXML, value);
                    WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryXML.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazkaXML.Id)));
                }
                catch (Exception ex) { }
            }
        }

        private String noweStreszczenie;
        public String NoweStreszczenie
        {
            get { return noweStreszczenie; }
            set
            {
                SetProperty(ref noweStreszczenie, value);
            }
        }

        private int usuwaneIDEFRozdzialu = 0;
        public int UsuwaneIDEFRozdzialu
        {
            get { return usuwaneIDEFRozdzialu; }
            set
            {
                if (Int32.TryParse(value.ToString(), out usuwaneIDEFRozdzialu))
                    SetProperty(ref usuwaneIDEFRozdzialu, value);
            }
        }

        private int usuwaneIDXMLRozdzialu = 0;
        public int UsuwaneIDXMLRozdzialu
        {
            get { return usuwaneIDXMLRozdzialu; }
            set
            {
                if (Int32.TryParse(value.ToString(), out usuwaneIDXMLRozdzialu))
                    SetProperty(ref usuwaneIDXMLRozdzialu, value);
            }
        }

        private int wybraneIDEFRozdzialu = 0;
        public int WybraneIDEFRozdzialu
        {
            get { return wybraneIDEFRozdzialu; }
            set
            {
                if (Int32.TryParse(value.ToString(), out wybraneIDEFRozdzialu))
                    SetProperty(ref wybraneIDEFRozdzialu, value);
            }
        }

        private int wybraneIDXMLRozdzialu = 0;
        public int WybraneIDXMLRozdzialu
        {
            get { return wybraneIDXMLRozdzialu; }
            set
            {
                if (Int32.TryParse(value.ToString(), out wybraneIDXMLRozdzialu))
                    SetProperty(ref wybraneIDXMLRozdzialu, value);
            }
        }

        private string nowaTrescRozdzialu;
        public string NowaTrescRozdzialu
        {
            get { return nowaTrescRozdzialu; }
            set
            {
                SetProperty(ref nowaTrescRozdzialu, value);
            }
        }

        public ICommand PokazWszystkieKsiazkiEFCommand { get; set; }
        public ICommand PokazKsiazkiOcenaEFCommand { get; set; }
        public ICommand UsunKsiazkeEFCommand { get; set; }
        public ICommand EdytujOceneKsiazkiEFCommand { get; set; }
        public ICommand DodajKsiazkeEFCommand { get; set; }

        public ICommand PokazWszystkieKsiazkiXMLCommand { get; set; }
        public ICommand PokazKsiazkiOcenaXMLCommand { get; set; }
        public ICommand UsunKsiazkeXMLCommand { get; set; }
        public ICommand EdytujOceneKsiazkiXMLCommand { get; set; }
        public ICommand DodajKsiazkeXMLCommand { get; set; }

        public ICommand PokazWszystkieRozdzialyEF { get; set; }
        public ICommand DodajStreszczenieCommand { get; set; }
        public ICommand UsunRozdzialEF { get; set; }
        public ICommand EdytujRozdzialEF { get; set; }

        public ICommand DodajStreszczenieCommandXML { get; set; }
        public ICommand UsunRozdzialXMLCommand { get; set; }
        public ICommand EdytujRozdzialXML { get; set; }

        #endregion
        public BiblioteczkaViewModel()
        {
            ksiazkaRepositoryEF= RepositoryFactory.Create<IKsiazkaRepository>(ContextTypes.EntityFramework);
            ksiazkaRepositoryXML= RepositoryFactory.Create<IKsiazkaRepository>(ContextTypes.XMLSource);
            rozdzialRepositoryEF = RepositoryFactory.Create<IRozdzialRepository>(ContextTypes.EntityFramework);
            rozdzialRepositoryXML = RepositoryFactory.Create<IRozdzialRepository>(ContextTypes.XMLSource);

            ListaKsiazekXML = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll());
            WybranaKsiazkaXML = ListaKsiazekXML.FirstOrDefault();
            WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryXML.GetAll().Where(r => (r.IdKsiazka == WybranaKsiazkaXML.Id)));

            ListaKsiazekEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll());
            WybranaKsiazkaEF = ListaKsiazekEF.FirstOrDefault();
            WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazka.Id)));

            PokazWszystkieKsiazkiEFCommand = new DelegateCommand(PokazWszystkieKsiazkiCommandEFExecute);
            PokazKsiazkiOcenaEFCommand = new DelegateCommand(PokazKsiazkiOcenaCommandEFExecute);
            UsunKsiazkeEFCommand = new DelegateCommand(UsunKsiazkeEFCommandExecute);
            EdytujOceneKsiazkiEFCommand = new DelegateCommand(EdytujOceneKsiazkiEFCommandExecute);
            DodajKsiazkeEFCommand = new DelegateCommand(DodajKsiazkeEFCommandExecute);

            PokazWszystkieKsiazkiXMLCommand = new DelegateCommand(PokazWszystkieKsiazkiCommandXMLExecute);
            PokazKsiazkiOcenaXMLCommand = new DelegateCommand(PokazKsiazkiOcenaCommandXMLExecute);
            UsunKsiazkeXMLCommand = new DelegateCommand(UsunKsiazkeXMLCommandExecute);
            EdytujOceneKsiazkiXMLCommand = new DelegateCommand(EdytujOceneKsiazkiXMLCommandExecute);
            DodajKsiazkeXMLCommand = new DelegateCommand(DodajKsiazkeXMLCommandExecute);

            PokazWszystkieRozdzialyEF = new DelegateCommand(PokazWszystkieRozdzialyEFExecute);
            DodajStreszczenieCommand = new DelegateCommand(DodajStreszczenieCommandExecute);
            UsunRozdzialEF = new DelegateCommand(UsunRozdzialEFExecute);
            EdytujRozdzialEF = new DelegateCommand(EdytujRozdzialEFExecute);

            DodajStreszczenieCommandXML = new DelegateCommand(DodajStreszczenieCommandXMLExecute);
            UsunRozdzialXMLCommand = new DelegateCommand(UsunRozdzialXMLCommandExecute);
            EdytujRozdzialXML = new DelegateCommand(EdytujRozdzialXMLExecute);
        }

        private void EdytujRozdzialXMLExecute()
        {
            try
            {
                Rozdzial edytowanyRozdzial = rozdzialRepositoryXML.Get(WybraneIDXMLRozdzialu);
                edytowanyRozdzial.Streszczenie = NowaTrescRozdzialu;
                rozdzialRepositoryXML.Delete(edytowanyRozdzial.Id);
                rozdzialRepositoryXML.Insert(edytowanyRozdzial);
                WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryXML.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazkaXML.Id)));
            }
            catch(Exception ex)
            {
                NowaTrescRozdzialu = "Błędny indeks rozdziału!";
            }
        }

        private void UsunRozdzialXMLCommandExecute()
        {
            try
            {
                rozdzialRepositoryXML.Delete(UsuwaneIDXMLRozdzialu);
                WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryXML.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazkaXML.Id)));
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
                System.Console.ReadKey();
            }
        }

        private void DodajStreszczenieCommandXMLExecute()
        {
            Rozdzial NowyRozdzial = new Rozdzial();
            int lastID;
            if (rozdzialRepositoryXML.GetAll().Count!=0) lastID=rozdzialRepositoryXML.GetAll().Max(x => x.Id); 
                    else lastID=0;
            //NowyRozdzial.IdKsiazka = WybranaKsiazkaEF.Id;
            NowyRozdzial.Streszczenie = NoweStreszczenie;
            //WybranaKsiazkaEF.Rozdzialy.Add(NowyRozdzial);
            NowyRozdzial.IdKsiazka = WybranaKsiazkaXML.Id;
            NowyRozdzial.Id = lastID + 1;
            rozdzialRepositoryXML.Insert(NowyRozdzial);
            WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryXML.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazkaXML.Id)));
        }

        public void UaktualnijListe()
        {
            ListaKsiazekEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll());
            WybranaKsiazkaEF = ListaKsiazekEF.FirstOrDefault();
            WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazka.Id)));

        }

        private void EdytujRozdzialEFExecute()
        {
            try
            {
                Rozdzial edytowanyRozdzial = rozdzialRepositoryEF.Get(WybraneIDEFRozdzialu);
                edytowanyRozdzial.Streszczenie = NowaTrescRozdzialu;
                rozdzialRepositoryEF.Update(edytowanyRozdzial);
                WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazka.Id)));
            }catch (Exception ex)
            {
                NowaTrescRozdzialu = "Błędny indeks rozdziału!";
            }
        }

        private void UsunRozdzialEFExecute()
        {
            try
            {
                rozdzialRepositoryEF.Delete(usuwaneIDEFRozdzialu);
                WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazka.Id)));
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
                System.Console.ReadKey();
            }
        }

        private void DodajStreszczenieCommandExecute()
        {
            Rozdzial NowyRozdzial = new Rozdzial();
            //NowyRozdzial.IdKsiazka = WybranaKsiazkaEF.Id;
            NowyRozdzial.Streszczenie = NoweStreszczenie;
            //WybranaKsiazkaEF.Rozdzialy.Add(NowyRozdzial);
            NowyRozdzial.IdKsiazka = WybranaKsiazkaEF.Id;
            rozdzialRepositoryEF.Insert(NowyRozdzial);
            WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll().Where(r => (r.IdKsiazka == wybranaKsiazka.Id)));
        }

        private void PokazWszystkieRozdzialyEFExecute()
        {
            wszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryEF.GetAll());
        }

        private void PokazWszystkieRozdzialyXMLExecute()
        {
            ListaKsiazekXML = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll());
            WybranaKsiazkaXML = ListaKsiazekXML.FirstOrDefault();
            WszystkieRozdzialy = new ObservableCollection<Rozdzial>(rozdzialRepositoryXML.GetAll().Where(r => (r.IdKsiazka == WybranaKsiazkaXML.Id)));
        }

        private void PokazWszystkieKsiazkiCommandXMLExecute()
        {
            WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll());
        }

        private void PokazKsiazkiOcenaCommandXMLExecute()
        {
            WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll().Where(x => x.Ocena > wybranaOcenaXML));
        }

        private void UsunKsiazkeXMLCommandExecute()
        {
            try
            {
                if (WybranaKsiazkaXML.Equals(ksiazkaRepositoryXML.Get(usuwaneIDXML)))
                    WybranaKsiazkaXML = ksiazkaRepositoryXML.GetAll().FirstOrDefault(k => k.Id != WybranaKsiazkaXML.Id);

                while(rozdzialRepositoryXML.GetAll().Where(r => r.IdKsiazka == usuwaneIDXML).Count()!=0)
                {
                    var rozdzial = rozdzialRepositoryXML.GetAll().FirstOrDefault(r => r.IdKsiazka == usuwaneIDXML);
                    rozdzialRepositoryXML.Delete(rozdzial.Id);
                }

                ksiazkaRepositoryXML.Delete(usuwaneIDXML);
                WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll());
                PokazWszystkieRozdzialyXMLExecute();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
                System.Console.ReadKey();
            }
        }

        private void EdytujOceneKsiazkiXMLCommandExecute()
        {
            try
            {
                Ksiazka edytowanaKsiazka = ksiazkaRepositoryXML.Get(wybraneIDXML);
                edytowanaKsiazka.Ocena = nowaOcenaXML;
                //ksiazkaRepositoryXML.Update(edytowanaKsiazka);
                ksiazkaRepositoryXML.Delete(wybraneIDXML);
                ksiazkaRepositoryXML.Insert(edytowanaKsiazka);
                WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll());
            }catch(Exception ex)
            {

            }
        }

        private void DodajKsiazkeXMLCommandExecute()
        {
            Ksiazka nowaKsiazka = new Ksiazka();
            int lastID = ksiazkaRepositoryXML.GetAll().Max(x => x.Id);
            nowaKsiazka.Id = lastID + 1;
            nowaKsiazka.Tytul = nowyTytul;
            nowaKsiazka.ImieAutora = nowyAutorImie;
            nowaKsiazka.NazwiskoAutora = nowyAutorNazwisko;
            nowaKsiazka.Ocena = nowaKsiazkaOcena;
            ksiazkaRepositoryXML.Insert(nowaKsiazka);
            PokazWszystkieRozdzialyXMLExecute();
            WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryXML.GetAll());
        }

        private void DodajKsiazkeEFCommandExecute()
        {
            Ksiazka nowaKsiazka = new Ksiazka();
            nowaKsiazka.Tytul = nowyTytul;
            nowaKsiazka.ImieAutora = nowyAutorImie;
            nowaKsiazka.NazwiskoAutora = nowyAutorNazwisko;
            nowaKsiazka.Ocena = nowaKsiazkaOcena;
            ksiazkaRepositoryEF.Insert(nowaKsiazka);
            WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll());
            UaktualnijListe();
        }

        private void EdytujOceneKsiazkiEFCommandExecute()
        {
            try
            {
                Ksiazka edytowanaKsiazka = ksiazkaRepositoryEF.Get(wybraneIDEF);
                edytowanaKsiazka.Ocena = nowaOcenaEF;
                ksiazkaRepositoryEF.Update(edytowanaKsiazka);
                WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UsunKsiazkeEFCommandExecute()
        {
            try
            {
                if (WybranaKsiazkaEF.Equals(ksiazkaRepositoryEF.Get(usuwaneIDEF)))
                    WybranaKsiazkaEF = ksiazkaRepositoryEF.GetAll().FirstOrDefault(k => k.Id != WybranaKsiazkaEF.Id);
                while (rozdzialRepositoryEF.GetAll().Where(r => r.IdKsiazka == usuwaneIDEF).Count() != 0)
                {
                    var rozdzial = rozdzialRepositoryEF.GetAll().FirstOrDefault(r => r.IdKsiazka == usuwaneIDEF);
                    rozdzialRepositoryEF.Delete(rozdzial.Id);
                }
                ksiazkaRepositoryEF.Delete(usuwaneIDEF);
                WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll());
                UaktualnijListe();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
                System.Console.ReadKey();
            }
        }

        private void PokazKsiazkiOcenaCommandEFExecute()
        {
            WszystkieKsiazkiEF= new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll().Where(x=>x.Ocena>wybranaOcenaEF));
        }

        private void PokazWszystkieKsiazkiCommandEFExecute()
        {
            WszystkieKsiazkiEF = new ObservableCollection<Ksiazka>(ksiazkaRepositoryEF.GetAll());
        }
    }
}
