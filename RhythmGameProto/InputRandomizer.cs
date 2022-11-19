using MacksInterestingMovement;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGameProto
{
    public class InputRandomizer
    {
        int temp;
        InputHandler inputHandler;

        public List<Keys[]> InputKeys;
        public int[] Indicies;

        Random rnd;

        public InputRandomizer(InputHandler inputHndlr)
        {
            rnd = new Random();
            inputHandler = inputHndlr;
            Indicies = new int[] { 0, 1, 2, 3 };
            InputKeys = setupInputKeys();
        }

        private List<Keys[]> setupInputKeys()
        {
            List<Keys[]> inputKeys = new List<Keys[]>();
            foreach(var key in inputHandler.inputKeys)
            {
                inputKeys.Add(key.Value);
            }
            return inputKeys;
        }

        public int[] shuffleKeys(int[] arry)
        {
            //maybe just shuffle and array of ints as it is faster
            //create an array of all the inputs in the player class
            //create an array of ints to shuffle
            
            //fisher yates shuffle
            int n = arry.Length;
            while(n > 1)
            {
                int k = rnd.Next(0, n);
                n--;
                int temp = arry[n];
                arry[n] = arry[k];
                arry[k] = temp;
            }
            foreach (var index in arry)
            {
                Debug.WriteLine(arry[index]);
            }
            temp++;
            Debug.WriteLine("--------" + temp.ToString());
            return arry;
        }



    }
}
