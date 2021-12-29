using System;

namespace PersonModelProject
{
    public class PersonList_class
    {
        private Person_class[] _personList = new Person_class[0];

        public void Add(Person_class person)
        {
            int currSize = _personList.Length;
            Array.Resize<Person_class>(ref _personList, currSize + 1);
            _personList[currSize] = person;
        }
        public void RemoveLast()
        {
            //TODO: сделать через один метод
            int currSize = _personList.Length;
            Array.Resize<Person_class>(ref _personList, currSize - 1);
        }
        public void RemoveIndex(int index)
        {
            int currSize = _personList.Length;
            Person_class[] tmpPersonlist = _personList;
            int tmpIndex = 0;
            _personList = new Person_class[currSize - 1];

            for (int i = 0; i < currSize; i++)
            {
                if (i != index)
                {
                    _personList[tmpIndex] = tmpPersonlist[i];
                    tmpIndex++;
                }
            }
        }
        public Person_class GetPersonByIndex(int index)
        {
            return _personList[index];
        }
        //TODO: indexOf
        public int GetIndexByPerson(Person_class person)
        {
            return Array.IndexOf(_personList, person);
        }
        public void Clear()
        {
            Array.Resize<Person_class>(ref _personList, 0);
        }

        //TODO: свойство
        public int Length()
        {
            return _personList.Length;
        }
    }
}
