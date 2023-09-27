using System;
using System.Collections.Generic;

public static class Telefono
{

    public static string Check(string[] input)
    {
        bool flag;    //variabile flag utilizzata per scartare o meno un numero in caso di errori di sintassi
        for (int i = 0; i<input.Length; i++){
            flag = false;      //utilizziamo false come stato del booleano per continuare i controlli
            foreach(char c in input[i]){
                if(!(c > 47 && c < 58) && c != 43 ){   //controlla se i caratteri all' intero della stringa sono accettabili utilizzando i valori della tabella ascii
                    flag = true;
                    break;  //dato che true è lo stato del booleano che scarta la stringa utilizziamo break per uscire dal ciclo
                }
            }
            if(flag){  //se il flag è true, si passa ai controlli successivi
                continue;
            }
            if(input[i].Length == 13 && (input[i][0] == '+' && input[i][1] == '3' && input[i][2] == '9' && input[i][3] == '3')){    //controlla il prefisso '+39'
                return input[i];
            } 
             else if (input[i].Length == 14 &&input[i][0] == '0' && input[i][1] == '0' && input[i][2] == '3' && input[i][3] == '9' && input[i][4] == '3'){  //controlla il prefisso '0039'
                return input[i];
            }
            else if (input[i].Length == 10 && input[i][0] == '3'){   //controlla il prefisso '3'
                return input[i];
            }
        }
        return "";   //ritorna "" se nessuno dei controlli precedenti è passato
    }
}