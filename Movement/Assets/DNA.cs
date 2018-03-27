using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA {

    List<int> genes = new List<int>();
    int dnaLength = 0;
    int maxValue = 0;

    //setting our dna to a specific length and maximum value
    public DNA(int l, int v)
    {
        dnaLength = l;
        maxValue = v;
        SetRandom();
    }

    //randomize values for all dna
    public void SetRandom()
    {
        genes.Clear();
        for (int i = 0; i < dnaLength; i++){
            genes.Add(Random.Range(0, maxValue));
        }
    }

    //set gene to certain value
    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    //first half recieves parent 1 dna, second half recieves parent 2 dna
    public void Combine(DNA d1, DNA d2)
    {
        for(int i = 0; i < dnaLength; i++)
        {
            if(i < dnaLength / 2.0)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

    //Mutate random gene value
    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValue);
    }

    //Return gene from given position
    public int GetGene(int pos)
    {
        return genes[pos];
    }

}
