using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static System.Windows.Visibility;

namespace Memory_game_WPF
{
    class Card
    {
        ////new list with cards 1 t/m 8 x2
        //private List<int> cards = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };

        //private void CardClick(object sender, MouseButtonEventArgs e)
        //    {
        //        Image card = (Image)sender;
        //        ImageSource front = (ImageSource)card.Tag;
        //        card.Source = front;
        //    }

        //    /// <summary>
        //    /// randomize image placement
        //    /// </summary>
        //    /// <returns>return een lijst met images</returns>
        //    private List<ImageSource> GetImagesList()
        //    {
        //        List<ImageSource> images = new List<ImageSource>();

        //        // rnd geeft een willekeurig getal terug
        //        Random rnd = new Random();

        //        for (int i = 0; i < 16; i++)
        //        {
        //            //index = rnd(random numer) that is not negative
        //            //lower then (cardNR.count){amount of items in list}
        //            int index = rnd.Next(cards.Count);
        //            int imageNR = cards[index];// ImageNR becomes cardNR[index] a random item{number} from the list cardNR
        //            cards.RemoveAt(index);//item gets removed from list.
        //            ImageSource source = new BitmapImage(new Uri("Resources/Kaart-Voorkant/" + imageNR + ".png", UriKind.Relative));
        //            images.Add(source);
        //        }
        //        return images;
    }
}

