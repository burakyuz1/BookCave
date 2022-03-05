using BookCave.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Persistance.EntityFramework
{
    public static class BookCaveDbContextSeed
    {
        public static async Task SeedDataAsync(BookCaveDbContext db)
        {
            if (db.Categories.Any() || db.Books.Any() || db.Authors.Any() || db.Publishers.Any()) return;

            Author author1 = new() { FullName = "David" };
            Author author2 = new() { FullName = "Jackson" };
            Author author3 = new() { FullName = "Beckham" };

            Category category1 = new() { Name = "Romance" };
            Category category2 = new() { Name = "Biography" };
            Category category3 = new() { Name = "Science-Fiction" };
            Category category4 = new() { Name = "Horror" };

            Publisher publisher1 = new() { Name = "Golden Books" };
            Publisher publisher2 = new() { Name = "Life Books" };
            Publisher publisher3 = new() { Name = "Flowers Books" };

            Book book1 = new()
            {
                ISBN = "9780679783268",
                Name = "Pride and Prejudice",
                Details = "Since its immediate success in 1813, Pride and Prejudice has remained one of the most popular novels in the English language. Jane Austen called this brilliant work \"her own darling child\" and its vivacious heroine, Elizabeth Bennet, \" as delightful a creature as ever appeared in print.\" The romantic clash English.",
                ImageUri = "pride.jpg",
                Stock = 20,
                Author = author2,
                Publisher = publisher1,
                NumberOfPages = 279,
                Status = true,
                UnitPrice = 20.99m,
                PublishYear = 2000
            };
            Book book2 = new()
            {
                ISBN = "1612130291134",
                Name = "Fifty Shades of Grey",
                Details = "When literature student Anastasia Steele goes to interview young entrepreneur Christian Grey, she encounters a man who is beautiful, brilliant, and intimidating. The unworldly, innocent Ana is startled to realize she wants this man and, despite his enigmatic reserve, finds she is desperate to get close to him.",
                ImageUri = "fifty.jpg",
                Stock = 20,
                Author = author3,
                Publisher = publisher2,
                NumberOfPages = 356,
                Status = true,
                UnitPrice = 49.37m,
                PublishYear = 2011
            };
            Book book3 = new()
            {
                ISBN = "6351478521657",
                Name = "Twilight",
                Details = "About three things I was absolutely positive.First,Edward was a vampire.Second,there was a part of him—and I didn't know how dominant that part might be—that thirsted for my blood.And third, I was unconditionally and irrevocably in love with him.Deeply seductive and extraordinarily suspenseful,Twilight is a love story with bite.",
                ImageUri = "twiligth.jpg",
                Stock = 20,
                Author = author1,
                Publisher = publisher1,
                NumberOfPages = 498,
                Status = true,
                UnitPrice = 15.33m,
                PublishYear = 2000
            };
            Book book4 = new()
            {
                ISBN = "2547897512312",
                Name = "Only a Monster",
                Details = "With the sweeping romance of Passenger and the dark fantasy edge of This Savage Song, this standout YA contemporary fantasy debut from Vanessa Len, is the first in a planned trilogy.It should have been the perfect summer.Sent to stay with her late mother’s eccentric family in London,  sixteen - year - old Joan is determined to enjoy herself.",
                ImageUri = "only.jpg",
                Stock = 20,
                Author = author1,
                Publisher = publisher1,
                NumberOfPages = 416,
                Status = true,
                UnitPrice = 40.44m,
                PublishYear = 2022
            };
            Book book5 = new()
            {
                ISBN = "2547227532312",
                Name = "These Deadly Games",
                Details = "When Crystal Donavan gets a message on a mysterious app with a video of her little sister gagged and bound, she agrees to play the kidnapper’s game. At first, they make her complete bizarre tasks: steal a test and stuff it in a locker, bake brownies, make a prank call.But then Crystal realizes each task is meant to hurt—and kill—her friends, one by one.",
                ImageUri = "these.jpg",
                Stock = 20,
                Author = author2,
                Publisher = publisher2,
                NumberOfPages = 279,
                Status = true,
                UnitPrice = 50.99m,
                PublishYear = 2014
            };
            Book book6 = new()
            {
                ISBN = "9781525804694",
                Name = "A Lullaby for Witches",
                Details = "Two women. A history of witchcraft. And a deep-rooted female power that sings across the centuries.Once there was a young woman from a well-to -do New England family who never quite fit with the drawing rooms and parlors of her kin.Called instead to the tangled woods and wild cliffs surrounding her family’s estate.",
                ImageUri = "lullaby.jpg",
                Stock = 20,
                Author = author3,
                Publisher = publisher3,
                NumberOfPages = 350,
                Status = true,
                UnitPrice = 65.99m,
                PublishYear = 2018
            };
            Book book7 = new()
            {
                ISBN = "9780345342966",
                Name = "Fahrenheit 451",
                Details = "Guy Montag is a fireman. His job is to destroy the most illegal of commodities, the printed book, along with the houses in which they are hidden. Montag never questions the destruction and ruin his actions produce, returning each day to his bland life and wife, Mildred, who spends all day with her television “family.”.",
                ImageUri = "fahrenheit.jpg",
                Stock = 20,
                Author = author2,
                Publisher = publisher1,
                NumberOfPages = 194,
                Status = true,
                UnitPrice = 45.55m,
                PublishYear = 2011
            };
            Book book8 = new()
            {
                ISBN = "9780439023481",
                Name = "The Hunger Games",
                Details = "In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl between the ages of twelve and eighteen to participate in the annual Hunger Games.",
                ImageUri = "thehunger.jpg",
                Stock = 20,
                Author = author2,
                Publisher = publisher1,
                NumberOfPages = 374,
                Status = true,
                UnitPrice = 27.95m,
                PublishYear = 2008
            };
            Book book9 = new()
            {
                ISBN = "9780140862539",
                Name = "1984",
                Details = "Among the seminal texts of the 20th century, Nineteen Eighty-Four is a rare work that grows more haunting as its futuristic purgatory becomes more real. Published in 1949, the book offers political satirist George Orwell's nightmarish vision of a totalitarian, bureaucratic world and one poor stiff's attempt to find individuality.",
                ImageUri = "1984.jpg",
                Stock = 20,
                Author = author2,
                Publisher = publisher1,
                NumberOfPages = 298,
                Status = true,
                UnitPrice = 32.99m,
                PublishYear = 2013
            };
            Book book10 = new()
            {
                ISBN = "9781451648546",
                Name = "Steve Jobs",
                Details = "Walter Isaacson's \"enthralling\" (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs. Based on more than forty interviews with Steve Jobs conducted over two years--as well as interviews with more than 100 family members, friends, adversaries, competitors.",
                ImageUri = "steve.jpg",
                Stock = 20,
                Author = author3,
                Publisher = publisher2,
                NumberOfPages = 627,
                Status = true,
                UnitPrice = 25.99m,
                PublishYear = 2011
            };
            Book book11 = new()
            {
                ISBN = "9781451648539",
                Name = "My Turn: The Autobiography",
                Details = "Johan Cruyff is widely regarded as one of the greatest players in football history. Throughout his playing career, he was synonymous with Total Football, a style of play in which every player could play in any position on the pitch. Today, his philosophy lives on in teams across Europe.",
                ImageUri = "myturn.jpg",
                Stock = 20,
                Author = author1,
                Publisher = publisher3,
                NumberOfPages = 320,
                Status = true,
                UnitPrice = 15.99m,
                PublishYear = 2016
            };
            Book book12 = new()
            {
                ISBN = "9781401310929",
                Name = "Nadal",
                Details = "What makes a champion? What does it take to be the best in the world at your sport? Rafael Nadal has the answers. In his memoir, written with award-winning journalist John Carlin, he reveals the secrets of his game and shares the inspiring personal story behind his success. It begins in Mallorca, where the tight-knit Nadal family has lived for generations.",
                ImageUri = "nadal.jpg",
                Stock = 20,
                Author = author2,
                Publisher = publisher1,
                NumberOfPages = 250,
                Status = true,
                UnitPrice = 13.95m,
                PublishYear = 2011
            };

            db.CategoryDetails.AddRange(
                new() { Book = book1, Category = category1 },
                new() { Book = book1, Category = category2 },
                new() { Book = book2, Category = category1 },
                new() { Book = book2, Category = category2 },
                new() { Book = book2, Category = category3 },
                new() { Book = book3, Category = category4 },
                new() { Book = book4, Category = category1 },
                new() { Book = book4, Category = category2 },
                new() { Book = book5, Category = category3 },
                new() { Book = book6, Category = category1 },
                new() { Book = book6, Category = category2 },
                new() { Book = book7, Category = category2 },
                new() { Book = book7, Category = category3 },
                new() { Book = book7, Category = category4 },
                new() { Book = book8, Category = category1 },
                new() { Book = book8, Category = category2 },
                new() { Book = book9, Category = category3 },
                new() { Book = book10, Category = category2 },
                new() { Book = book10, Category = category3 },
                new() { Book = book11, Category = category1 },
                new() { Book = book11, Category = category4 },
                new() { Book = book12, Category = category2 }
                );

            await db.SaveChangesAsync();

        }
    }
}
