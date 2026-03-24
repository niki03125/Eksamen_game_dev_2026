# 🎮 Eksamen Game Dev 2026

## 🧠 Om projektet

Dette projekt er udviklet som en del af vores game development eksamen.
Spillet er et horror/investigation spil, hvor spilleren bevæger sig rundt i et bibliotek og interagerer med objekter for at løse en central opgave.

Temaet er inspireret af mystik og spænding, hvor spilleren skal finde en særlig bog for at stoppe en trussel.

---

## 🎯 Gameplay

* Spilleren bevæger sig rundt i et bibliotek
* Interaktion med objekter via tast (fx **R**)
* En særlig "ghost book" spiller en central rolle
* Når den rigtige bog findes:

  * Et partikkelsystem aktiveres (VFX)
  * Spilleren kan fjerne spøgelset
  * Spillet vindes

---

## ⚙️ Funktioner (Features)

### 🧍 Player

* Movement system
* UI (health / stamina)

### 📚 Interaktive objekter

* Bøger der falder (med physics / Rigidbody)
* Trigger system (player proximity)
* Input-baseret interaction

### 👻 Ghost system

* Ghost objekt der kan destrueres
* Koblet til gameplay mål

### ✨ VFX (Visual Effects)

* Particle System brugt til:

  * Ghost book highlight
  * Visuel feedback til spilleren

### 🔊 SFX (Sound Effects)

* Lyd når bøger falder
* Baggrundslyd (ambient)

---

## 🛠️ Teknologier

* Unity (Game Engine)
* C#
* Git & GitHub (versionsstyring)

---

## 📜 Eksempel på central kode

Et eksempel på vores interaktionssystem:

```csharp
if (bookOnFloor && playerNearby && Input.GetKeyDown(KeyCode.R))
{
    if (ghost != null)
    {
        Destroy(ghost);
        winTextObject.SetActive(true);
    }
    Destroy(gameObject);
}
```

Dette viser hvordan spilleren kan interagere med den rigtige bog og fuldføre spillet.

---

## 🚀 Sådan kører du projektet

1. Clone repository:

   ```bash
   git clone https://github.com/niki03125/Eksamen_game_dev_2026
   ```

2. Åbn projektet i Unity Hub

3. Åbn den relevante scene

4. Tryk **Play**

---

## 👥 Gruppe

Projektet er lavet af en gruppe studerende som en del af eksamen i game development.

---

## 💡 Læring

Gennem projektet har vi arbejdet med:

* Unity basics (GameObjects, Components)
* Scripts i C#
* Physics (Rigidbody & Colliders)
* Particle Systems (VFX)
* Lyd (Audio Source)
* Git samarbejde

---

## 📌 Note

Projektet er lavet til læring og eksamen, og ikke som et færdigt kommercielt spil.

---
