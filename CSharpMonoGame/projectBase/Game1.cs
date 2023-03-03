using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectBase
{
      // Classe principale du jeu
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random monDe = new Random(System.DateTime.Now.Millisecond);
        public int Lance1D(int nombreDeFace)
        {
            int resultatDe = monDe.Next(1, nombreDeFace+1);
            return resultatDe;
        }





        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        // Fonction appelée une fois pour initialiser le jeu
        protected override void Initialize()
        {
            // TODO: Ajoutez ici votre code d'initialisation
            System.Console.WriteLine("Hey");

            // Type numérique entiers
            int nNombreDeVie = 5;
            int nEnergie = 100;
            System.Console.WriteLine("j'ai actuelement {0} vies et {1} point d'énergie !", nNombreDeVie, nEnergie);

            float nPos = 1.5f;
            System.Console.WriteLine("Mon float nPos vaut : "+ nPos);

            bool bDoorClosed; 
            bDoorClosed = false;
            System.Console.WriteLine("Ma porte est-elle close ? " + bDoorClosed);
            bDoorClosed = true;
            System.Console.WriteLine("Ma porte est-elle close ? " + bDoorClosed);
            char cInitiale = 'c';
            System.Console.WriteLine("Initiale : " + cInitiale);

            // Type chaine de caractere
            string sMessageJoueur = "";
            sMessageJoueur = "Il reste "+ nEnergie + " points d'énergie";
            System.Console.WriteLine(sMessageJoueur);
            System.Console.WriteLine("La chaine fait " + sMessageJoueur.Length + " charactères");

            int resultat;
            resultat = Lance1D(6);
            Console.WriteLine("Le resultat du D6 est " + resultat);
            resultat = Lance1D(20);
            Console.WriteLine("Le resultat des D20 est " + resultat);

            // int i = 1; : initialisation / i <= 10; : vérification / i++ : incrémentation
            for (int i = 1; i <= 10; i++)
            {
                int monDe = Lance1D(6);
                Console.WriteLine("Au lancement du D" + i + " J'ai obtenue : " + monDe);
            }

            // while quand on ne sais pas cb de x on vas devoir executer la function (exemple generation de x aléatoire)
            int j = 1;
            while(j<10)
            {
                Console.WriteLine("Mon compteur j du while vaut : " + j);
                j++;
            }

            j = 1;
            do
            {
                Console.WriteLine("Mon compteur j du do/while vaut : " + j);
                j++;
            }while(j<10);

            // tableau : int
            int[] tableau1;
            //                        0, 1, 2, 3, 4
            tableau1 = new int[5] { 1, 4, 6, 2, 9 };
            System.Console.WriteLine("Element 0 : "+ tableau1[1]);

            // tableau : string
            string[] classes;
            classes = new string[] { "Barbare", "Barde", "Druide", "Ensorceleur", "Guerrier", "Magicien" };

            string[] races = new string[] { "Humain", "Elfe", "Nain", "Gnome" };
            System.Console.WriteLine("Nombre de races : " + races.Length);

            for (int i = 0; i < races.Length; i++)
            {


            }








            base.Initialize();
        }

        // Fonction appelée une seule fois pour charger le contenu du jeu
        protected override void LoadContent()
        {
            // Crée un nouveau SpriteBatch, qui sera utilisé pour afficher des images (textures)
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Ajoutez ici votre code qui chargera le contenu du jeu
        }

        // Fonction appelée une fois pour décharger le contenu du jeu (hors ContentManager)
        protected override void UnloadContent()
        {
            
        }

        // Fonction appelée 60x par seconde pour mettre à jour l'état du jeu
        // Reçoit "gametime" qui contient le temps écoulé depuis le dernier update
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Ajoutez le code de mise à jour ici

            base.Update(gameTime);
        }

        // Fonction appelée aussi souvent que possible (jusqu'à 60x par seconde) pour afficher le jeu
        // Reçoit "gametime" qui contient le temps écoulé depuis le dernier update
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Ajouter le code d'affichage ici

            base.Draw(gameTime);
        }
    }
}
