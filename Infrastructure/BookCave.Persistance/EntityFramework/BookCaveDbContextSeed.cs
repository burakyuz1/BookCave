using BookCave.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Persistance.EntityFramework
{
    public static class BookCaveDbContextSeed
    {
        public static async Task SeedDataAsync(BookCaveDbContext db)
        {
            if (db.Categories.Any() || db.Books.Any() || db.Authors.Any() || db.Publishers.Any()) return;

            Author richardDawkins = new() { FullName = "Richard Dawkins" };
            Author stephanHawkings = new() { FullName = "Stephan Hawkings" };
            Author dostoevsky = new() { FullName = "Fyodor Dostoevsky" };
            Author frankHerbert = new() { FullName = "Frank Herbert" };
            Author stephenKing = new() { FullName = "Stephen King" };
            Author jeanGrange = new() { FullName = "Jean C. Grange" };

            Category classic = new() { Name = "Classic" };
            Category science = new() { Name = "Science" };
            Category horror = new() { Name = "Horror" };

            Publisher goldenBook = new() { Name = "Golden Book" };
            Publisher flowerBook = new() { Name = "Flower Book" };
            Publisher appleBook = new() { Name = "Apple Book" };

            Book book1 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The Selfish Gene",
                Details = "Inheriting the mantle of revolutionary biologist from Darwin, Watson, and Crick, Richard Dawkins forced an enormous change in the way we see ourselves and the world with the publication of The Selfish Gene. Suppose, instead of thinking about organisms using genes to reproduce themselves, as we had since Mendel's work was rediscovered, we turn it around and imagine that \"our\" genes build and maintain us in order to make more genes.",
                ImageUri = "selfish.jpg",
                Stock = 50,
                Author = richardDawkins,
                Publisher = goldenBook,
                NumberOfPages = 360,
                Status = true,
                UnitPrice = 20.99m,
                PublishYear = 1976,
                Category = science
            };
            Book book2 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The God Delusion",
                Details = "A preeminent scientist - and the world's most prominent atheist - asserts the irrationality of belief in God, and the grievous harm religion has inflicted on society, from the Crusades to 9/11. With rigor and wit,Dawkins examines God in all his forms,from the sex-obsessed tyrant of the Old Testament, to the more benign(but still illogical) Celestial Watchmaker favored by some Enlightenment thinkers. ",
                ImageUri = "thegod.jpg",
                Stock = 50,
                Author = richardDawkins,
                Publisher = flowerBook,
                NumberOfPages = 374,
                Status = true,
                UnitPrice = 19.37m,
                PublishYear = 2006,
                Category = science
            };
            Book book3 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The Grand Design",
                Details = "THE FIRST MAJOR WORK IN NEARLY A DECADE BY ONE OF THE WORLD’S GREAT THINKERS—A MARVELOUSLY CONCISE BOOK WITH NEW ANSWERS TO THE ULTIMATE QUESTIONS OF LIFE When and how did the universe begin ? Why are we here ? Why is there something rather than nothing ? What is the nature of reality ? Why are the laws of nature so finely tuned as to allow for the existence of beings like ourselves ? ",
                ImageUri = "thegrand.jpg",
                Stock = 50,
                Author = stephanHawkings,
                Publisher = appleBook,
                NumberOfPages = 199,
                Status = true,
                UnitPrice = 15.33m,
                PublishYear = 2010,
                Category = science
            };

            Book book4 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The Brothers Kramazov",
                Details = "The Brothers Karamazov is a murder mystery, a courtroom drama, and an exploration of erotic rivalry in a series of triangular love affairs involving the “wicked and sentimental” Fyodor Pavlovich Karamazov and his three sons―the impulsive and sensual Dmitri; the coldly rational Ivan; and the healthy, red-cheeked young novice Alyosha.",
                ImageUri = "thebrotherskramazov.jpg",
                Stock = 50,
                Author = dostoevsky,
                Publisher = appleBook,
                NumberOfPages = 769,
                Status = true,
                UnitPrice = 52.44m,
                PublishYear = 2002,
                Category = classic
            };
            Book book5 = new()
            {
                ISBN = GenerateISBN(),
                Name = "Crime and Punishment",
                Details = "Raskolnikov, a destitute and desperate former student, wanders through the slums of St Petersburg and commits a random murder without remorse or regret. He imagines himself to be a great man, a Napoleon: acting for a higher purpose beyond conventional moral law.",
                ImageUri = "crimeandpunishment.jpg",
                Stock = 50,
                Author = dostoevsky,
                Publisher = goldenBook,
                NumberOfPages = 671,
                Status = true,
                UnitPrice = 48.99m,
                PublishYear = 2002,
                Category = classic
            };
            Book book6 = new()
            {
                ISBN = GenerateISBN(),
                Name = "Dune",
                Details = "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides, heir to a noble family tasked with ruling an inhospitable world where the only thing of value is the “spice” melange, a drug capable of extending life and enhancing consciousness.",
                ImageUri = "dune.jpg",
                Stock = 20,
                Author = frankHerbert,
                Publisher = flowerBook,
                NumberOfPages = 658,
                Status = true,
                UnitPrice = 65.99m,
                PublishYear = 2002,
                Category = classic
            };

            Book book7 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The Outside",
                Details = "An unspeakable crime. A confounding investigation. At a time when the King brand has never been stronger, he has delivered one of his most unsettling and compulsively readable stories.",
                ImageUri = "outside.jpg",
                Stock = 50,
                Author = stephenKing,
                Publisher = goldenBook,
                NumberOfPages = 514,
                Status = true,
                UnitPrice = 12.37m,
                PublishYear = 2018,
                Category = horror
            };
            Book book8 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The Gunslinger",
                Details = "In the first book of this brilliant series, Stephen King introduces readers to one of his most enigmatic heroes, Roland of Gilead, The Last Gunslinger. He is a haunting figure, a loner on a spellbinding journey into good and evil. In his desolate world, which frighteningly mirrors our own, Roland pursues The Man in Black, encounters an alluring woman named Alice, and begins a friendship with the Kid from Earth called Jake.",
                ImageUri = "gunslinger.jpg",
                Stock = 50,
                Author = stephenKing,
                Publisher = appleBook,
                NumberOfPages = 514,
                Status = true,
                UnitPrice = 22.37m,
                PublishYear = 2011,
                Category = horror
            };
            Book book9 = new()
            {
                ISBN = GenerateISBN(),
                Name = "Congo Requirem",
                Details = "Details:On ne choisit pas sa famille mais le diable a choisi son clan.Alors que Grégoire et Erwan traquent la vérité jusqu'à Lontano, au coeur des ténèbres africaines, Loïc et Gaëlle affrontent un nouveau tueur à Florence et à Paris.",

                ImageUri = "congo.jpg",
                Stock = 50,
                Author = jeanGrange,
                Publisher = flowerBook,
                NumberOfPages = 612,
                Status = true,
                UnitPrice = 33.37m,
                PublishYear = 2012,
                Category = horror
            };


            Book book10 = new()
            {
                ISBN = GenerateISBN(),
                Name = "My Brief History",
                Details = "Stephen Hawking has dazzled readers worldwide with a string of bestsellers exploring the mysteries of the universe. Now, for the first time, perhaps the most brilliant cosmologist of our age turns his gaze inward for a revealing look at his own life and intellectual evolution. My Brief History recounts Stephen Hawking’s improbable journey, from his postwar London boyhood to his years of international acclaim and celebrity.",
                ImageUri = "mybreaf.jpg",
                Stock = 50,
                Author = stephanHawkings,
                Publisher = appleBook,
                NumberOfPages = 126,
                Status = true,
                UnitPrice = 5.99m,
                PublishYear = 2013,
                Category = science
            };
            Book book11 = new()
            {
                ISBN = GenerateISBN(),
                Name = "The White Plague",
                Details = "The White Plague, a marvelous and terrifyingly plausible blend of fiction and visionary theme, tells of one man who is pushed over the edge of sanity by the senseless murder of his family and who, reappearing several months later as the so-called Madman, unleashes a terrible plague upon the human race—one that zeros in, unerringly and fatally, on women.",
                ImageUri = "thewhiteplague.jpg",
                Stock = 50,
                Author = frankHerbert,
                Publisher = appleBook,
                NumberOfPages = 502,
                Status = true,
                UnitPrice = 29.37m,
                PublishYear = 1983,
                Category = science
            };
            Book book12 = new()
            {
                ISBN = GenerateISBN(),
                Name = "Le Passager",
                Details = "Je suis l'ombre. Je suis la proie. Je suis le tueur. Je suis la cible. Pour m'en sortir, une seule option : fuir l'autre. Mais si l'autre est moi-même ?",
                ImageUri = "lepassager.jpg",
                Stock = 50,
                Author = jeanGrange,
                Publisher = flowerBook,
                NumberOfPages = 514,
                Status = true,
                UnitPrice = 14.37m,
                PublishYear = 2019,
                Category = horror
            };

            db.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12);

            await db.SaveChangesAsync();
        }
        private static string GenerateISBN()
        {
            int isbn1 = new Random().Next(100000, 999999);
            int isbn2 = new Random().Next(1000000, 9999999);
            return isbn1.ToString() + isbn2.ToString();
        }
    }
}
