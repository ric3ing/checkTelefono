# Traccia originale:
Ricevuto come parametro un vettore di string, ritornare al chiamante la prima stringa che assomiglia molto ad un numero di telefono cellulare italiano ovvero:
- che inizia con +39 (esattamente lungo  13)
- oppure con 0039 (esattamente lungo 14)
- oppure con un 3 (esattamente lungo 10)

Se il numero non viene trovato, ritornare stringa vuota ""

Ad esempio.
Se arriva "05417373", "3367726712",  "778823"
Tornare "3367726712"

Se arriva "33677267", "33677232",  "778823"
Tornare ""

Se arriva "", "05417723",  "+391231231234"
Tornare "+391231231234"

Se arriva "3", "05417723",  "00391231231230"
Tornare ""

etc

--------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Come è stato sviluppato il codice?
Partendo da una funzione predefinita chiamata *Check* , ci si pone subito il problema di scartare i numeri di telefono che presentano errori di sintassi (spazi, lettere, simboli...). Il problema iniziale è facilmente risolvibile utilizzando una **flag** :



```C#
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

```

Utilizzando un costrutto iterativo foreach, si controllano singolarmente i caratteri all'interno della stringa del numero di telefono e, utilizzando i valori della tabella ascii, si controlla che i caratteri siano diversi da:
<ul>
<li>dei numeri;</li>
 <li>un "+".</li>
</ul>
Se la condizione risulta verificata correttamente, flag diventa true e quindi si esce dal ciclo scartando la stringa.
<br>

--------------------------------------------------------------------------------------------------------------------------------------------------------------------
Si procede poi controllando il prefisso della stringa: se qualora il prefisso rispetti i canoni imposti dalla consegna, si ritornerà la stringa in questione; in caso contrario, il programma ritornerà "", come da consegna.

```C#

if(input[i].Length == 13 && (input[i][0] == '+' && input[i][1] == '3' && input[i][2] == '9' && input[i][3] == '3')){    //controlla il prefisso '+39'
                return input[i];
            } 
             else if (input[i].Length == 14 &&input[i][0] == '0' && input[i][1] == '0' && input[i][2] == '3' && input[i][3] == '9' && input[i][4] == '3'){  //controlla il prefisso '0039'
                return input[i];
            }
            else if (input[i].Length == 10 && input[i][0] == '3'){   //controlla il prefisso '3'
                return input[i];
            }

```
