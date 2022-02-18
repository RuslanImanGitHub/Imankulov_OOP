using System;

namespace PersonModelProject
{
    /// <summary>
    /// Class list of persons
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// New array of person
        /// </summary>
        private Person[] _personList = new Person[0];

        /// <summary>
        /// Length of PersonList
        /// </summary>
        public int Length => _personList.Length;

        /// <summary>
        /// Add new entry in PersonList
        /// </summary>
        /// <param name="person">Person object</param>
        public void Add(Person person)
        {
            int currSize = _personList.Length;
            Array.Resize<Person>(ref _personList, currSize + 1);
            _personList[currSize] = person;
        }

        /// <summary>
        /// Removes last object from PersonList
        /// </summary>
        public void RemoveLast()
        {
            if (_personList.Length > 1)
            {
                int currSize = _personList.Length;
                Array.Resize<Person>(ref _personList, currSize - 1);
            }
            else
            {
                Console.WriteLine("This PersonList contains only one entity");
            }

        }

        /// <summary>
        /// Removes object specified by index
        /// </summary>
        /// <param name="index">Index of object to remove</param>
        public void RemoveIndex(int index)
        {
            int currSize = _personList.Length;
            Person[] tmpPersonlist = _personList;
            int tmpIndex = 0;
            _personList = new Person[currSize - 1];

            for (int i = 0; i < currSize; i++)
            {
                if (i != index)
                {
                    _personList[tmpIndex] = tmpPersonlist[i];
                    tmpIndex++;
                }
            }
        }

        /// <summary>
        /// Returns object specified by index
        /// </summary>
        /// <param name="index">Index of object to return</param>
        /// <returns></returns>
        public Person GetPersonByIndex(int index)
        {
            return _personList[index];
        }
        
        /// <summary>
        /// Returns index of specified object from PersonList
        /// </summary>
        /// <param name="person">Object which index is needed</param>
        /// <returns></returns>
        public int GetIndexOfPerson(Person person)
        {
            return Array.IndexOf(_personList, person);
        }

        /// <summary>
        /// Clears PersonList
        /// </summary>
        public void Clear()
        {
            Array.Resize<Person>(ref _personList, 0);
        }
    }
}
