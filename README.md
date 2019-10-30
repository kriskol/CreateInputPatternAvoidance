# CreateInputPatternAvoidance
Creates input for project Pattern-avoidance-detection.

## Format vstupu:
`F` `S` `E`

Kde `F` je vstupny subor, `S` je zaciatocny index a `E` je konecny index.
Kde program bude formatovat od `S`-teho vstupu po `E` (nevratane).
Ak chceme formatovat vsetky vstupy, tak staci nastavit `S` a `E`, tak aby `E < S`.

Kde `F` je subor obsahujuci vstupne permutacie a pocet ich avoider-ov v nasledujucej podobe:
`#123`
`1 2 5`
`#12`
`1 1 1 ...`

Majme vstup, kde
`F` ma podobu
`#123`
`1 2 5`
`#12`
`1 1 1`

`S` je `0` na `E` je `1`.

Vystup budu 2 subory: `0.in` a `c0.out`.

Subor `0.in` je v tvare:
`0-1-2`

Subor `c0.in` je v tvare:
`1`
`2`
`5` , kde kazde cislo bude na samostatnom riadku.
