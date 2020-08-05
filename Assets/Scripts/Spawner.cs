using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectible;
    string[] randomstrings = new string[46];

    Vector3 position;


    private static System.Random random = new System.Random();

  
    
    // Start is called before the first frame update
    void Start()
    {


        randomstrings = Randommix();
        // Debug.Log(RandomString());



        //     for (int i=0;i<randomstrings.Length;i++)
        //  {
        //       palindromecheck(randomstrings[i]);
        //
        //  }


        int spawned = 0;
        int cubestring = 0;

        while (spawned < randomstrings.Length)
        {
            position = new Vector3(UnityEngine.Random.Range(-8.1f, 37.8f), 0.5f, UnityEngine.Random.Range(18.4f, -28.2f));

            GameObject newobject = Instantiate(collectible, position, Quaternion.identity);
            newobject.GetComponent<Checker>().nameLable.text = randomstrings[cubestring];
            cubestring++;

            spawned++;
        }
        collectible.SetActive(false);
        Destroy(collectible);

    }


    public string[] Randommix()
    {
        //my reg no 16 <30 so 16+30=46 so i need 46/3 = 18 matching bracket strings
        string[] mixed = new string[46];
        string generated;
        for (int i = 0; i < 18; i++)
        {
            generated = Randomstrings();
          //  if (Matchingcheck(generated)) // function with loop and stack
            if (TuringMachinebrackets(generated))  //turing machine with tape, states and symbols
            {
                mixed[i] = generated;

            }
            else
            {
                i--;
            }

        }
        // from 18 onwards non balanced brackets, to make sure running them through check function again.
        for (int i = 18; i < 46; i++)
        {
            generated = Randomstrings();
           // if (!Matchingcheck(generated))
           if(!TuringMachinebrackets(generated))
            {
                mixed[i] = generated;
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < mixed.Length; i++)
        {
            Console.WriteLine(i + " :" + mixed[i].ToString());
        }


        return mixed;
    }
    public string Randomstrings()
    {

        const string chars = "x(m)6";
        return new string(Enumerable.Repeat(chars, random.Next(9, 15))
           .Select(s => s[random.Next(s.Length)]).ToArray());

    }



    public static bool Matchingcheck(string input)
    {

        Stack<char> brackets = new Stack<char>();

        try
        {
            foreach (char c in input)
            {
                if (c == '(')
                {
                    brackets.Push(c);
                }
                else
                    if (c == ')')
                {
                    if (brackets.Count != 0)
                    {
                        brackets.Pop();
                    }
                    else
                        return false;
                }
                else
                    continue;
            }
        }
        catch
        {
            return false;
        }
        return brackets.Count() == 0 ? true : false;
    }













    public static bool TuringMachinebrackets(string cubestring)
    {
        
      //initial state= A 
            string currentstate = "A";
            //states = A , B , C , D
            //symbols= (,),x,m,6
            Tape tape = new Tape();
            tape.setTapeState(cubestring);

            string nextsymbol;

            void getnewsymbol()

            {
                    nextsymbol = tape.gettapeat(tape.getCurrentPosition());
 
            }

            nextsymbol = tape.gettapeat(tape.getCurrentPosition());
            while (true)
            {

                

                if (currentstate == "A")
                {
                    if (nextsymbol == "x" || nextsymbol == "(" || nextsymbol == "6" || nextsymbol == "m" || currentstate == "O")
                    {


                        tape.goRight();
                        getnewsymbol();

                    }
                    else if (nextsymbol == ")")
                    {

                        tape.replaceCell(char.Parse("O"));
                        currentstate = "B";

                     

                        tape.goLeft();
                        getnewsymbol();

                    }
                    else if (nextsymbol == "$")
                    {
                        currentstate = "C";


                        tape.goLeft();

                        getnewsymbol();

                    }
                    else

                    {
                        tape.goRight();
                        getnewsymbol();
                    }

                }
                if (currentstate == "B")
                {
                    if (nextsymbol == "(")
                    {
                        tape.replaceCell(char.Parse("O"));
                        currentstate = "A";


                        tape.goRight();
                        getnewsymbol();
                    }
                    else if (nextsymbol == "$")
                    {
                        return false;

                    }
                    else
                    {
                        tape.goLeft();
                        getnewsymbol();
                    }
                }
                if (currentstate == "C")
                {
                    if (nextsymbol == "$")
                    {
                        currentstate = "D";
                        getnewsymbol();


                    }
                    else if (nextsymbol == "(")
                    {
                        return false;
                    }
                    else
                    {
                        tape.goLeft();
                        getnewsymbol();
                    }
                }

              
                if (currentstate == "D")
                {

                    return true;
                }
                else
                {
                    continue;
                }

            }

      
    }




    public class Tape
    {
        const int tapeLimit = 50;
        const int tapeStart = tapeLimit / 5;
        int cur_pos;
        char[] _tape = new char[tapeLimit];

        public Tape()
        {
            for (int i = 0; i < tapeLimit; i++)
                _tape[i] = '$';
            cur_pos = tapeStart;
        }

        public string getTapeState()
        {
            return new string(_tape);
        }

        public void setTapeState(string inputText)
        {
            for (int i = tapeStart; i < tapeStart + inputText.Length; i++)
                _tape[i] = inputText[i - tapeStart];


        }

        public string gettape()
        {
            string tapestring = "";
            for (int i = 0; i < tapeLimit; i++)
            {
                tapestring += _tape[i];
            }
            return tapestring;
        }

        public string gettapeat(int index)
        {
            string item = _tape[index].ToString();
            return item;
        }

        public int getCurrentPosition()
        {
            return cur_pos;
        }

        public void goLeft()
        {
            cur_pos--;
        }

        public void goRight()
        {
            cur_pos++;
        }

        public void replaceCell(char newChar)
        {
            _tape[cur_pos] = newChar;
        }
    }


}







