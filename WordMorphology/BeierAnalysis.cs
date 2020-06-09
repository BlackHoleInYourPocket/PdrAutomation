using net.zemberek.erisim;
using net.zemberek.tr.yapi;
using net.zemberek.yapi;

namespace WordMorphology
{
    public class BeierAnalysis
    {
        Zemberek zemberek = new Zemberek(new TurkiyeTurkcesi());

        public string BeierEk(string word)
        {
            try
            {
                Kelime[] kelime = zemberek.kelimeCozumle(word);
                return kelime[0].ekler()[0].ad();
            }
            catch (System.Exception)
            {

                return "";
            }
        }
        public string BeierKök(string word)
        {
            try
            {
                Kelime[] kelime = zemberek.kelimeCozumle(word);
                return kelime[0].kok().icerik();
            }
            catch (System.Exception)
            {

                return "";
            }
        }
    }
}
