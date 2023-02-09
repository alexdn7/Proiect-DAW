# Proiect-DAW

-- Modelele:

  Produs, despre care se rețin diferite informații, precum denumire, descriere, o imagine a acestuia, dar și producătorul, respectiv vânzătorul acestuia.
  Vanzator, aici rețin denumirile diferiților vânzători, dar și un număr de contact.
  
  Între Produs și Vanzator am avea relație M - M (un produs poate fi vandut de mai multi vanzatori, dar si un vanzator poate vinde mai multe produse), astfel fiind necesara introducerea tabelului asociativ Produs_Vanzator.
  
  Producator, se retin denumirea, descrierea, dar și ID-ul locației în care se află. (1 - 1 cu Locatie, 1 - M cu Produs)
  Locatie, se retin numele tarii, orasului si al strazii.
  
  
 - 3 Controllere (minim); Fiecare Metoda Crud, REST cu date din baza de date. (1p) 🟢
 
 -Cel puțin 1 relație între tabele din fiecare fel (One to One, Many to Many, One to Many); Folosirea metodelor din Linq: GroupBy, Where, etc; Folosirea Join si Include (1p) 🟢
 
 -Autentificare + Roluri; Autorizare pe endpointuri în funcție de Roluri; Cel putin 2 Roluri: Admin, User (1p) 🟢
 
 -Sa se foloseasca repository pattern + Service (1p) 🟢
 
 - Unit of work (1 pct) 🟢
