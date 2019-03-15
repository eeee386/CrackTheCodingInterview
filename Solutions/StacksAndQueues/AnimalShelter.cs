using System.Collections.Generic;

namespace Solutions.StacksAndQueues
{
    public class Animal
    {
        public int order;
    }

    public class Cat : Animal
    {
    }

    public class Dog : Animal
    {
    }

    public class AnimalShelter
    {
        private int orderCounter = 0;
        LinkedList<Dog> dogQueue = new LinkedList<Dog>();
        LinkedList<Cat> catQueue = new LinkedList<Cat>();

        public void Enqueue(Animal animal)
        {
            orderCounter++;
            if (animal is Cat cat)
            {
                cat.order = orderCounter;
                catQueue.AddFirst(cat);
            }

            if (animal is Dog dog)
            {
                dog.order = orderCounter;
                dogQueue.AddFirst(dog);
            }
        }

        public Animal DequeueAny()
        {
            Cat lastCat = catQueue.Last.Value;
            Dog lastDog = dogQueue.Last.Value;
            if (lastCat.order > lastDog.order)
            {
                catQueue.RemoveLast();
                return lastCat;
            }
            dogQueue.RemoveLast();
            return lastDog;
        }

        public Dog DequeueDog()
        {
            Dog dog = dogQueue.Last.Value;
            dogQueue.RemoveLast();
            return dog;
        }

        public Cat DequeueCat()
        {
            Cat cat = catQueue.Last.Value;
            catQueue.RemoveLast();
            return cat;
        }

    }
}