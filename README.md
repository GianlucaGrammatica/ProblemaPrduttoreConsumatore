## Problema Produttore-Consumatore Con C# e Multithreading
In informatica, il problema del produttore-consumatore (conosciuto anche con il nome di problema del buffer limitato o bounded-buffer problem) è un esempio classico di sincronizzazione tra processi. Il problema descrive due processi, uno produttore (in inglese producer) ed uno consumatore (consumer), che condividono un buffer comune, di dimensione fissata. Compito del produttore è generare dati e depositarli nel buffer in continuo. Contemporaneamente, il consumatore utilizzerà i dati prodotti, rimuovendoli di volta in volta dal buffer. Il problema è assicurare che il produttore non elabori nuovi dati se il buffer è pieno, e che il consumatore non cerchi dati se il buffer è vuoto.

La soluzione per il produttore è sospendere la propria esecuzione se il buffer è pieno; non appena il consumatore avrà prelevato un elemento dal buffer, esso "sveglierà" il produttore, che ricomincerà quindi a riempire il buffer. Allo stesso modo, il consumatore si sospenderà se il buffer è vuoto; non appena il produttore avrà scaricato dati nel buffer, risveglierà il consumatore. Questa soluzione può essere implementata tramite delle strategie di comunicazione tra processi, tipicamente con dei semafori. Una soluzione errata potrebbe dar luogo ad un deadlock, in cui entrambi i processi aspettano di essere risvegliati.

![IMG](https://miro.medium.com/v2/resize:fit:1121/0*BiEx-68nz8E4zzNb.png)
