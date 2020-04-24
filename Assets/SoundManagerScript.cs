using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip EnemyHit1, EnemyHit2, EnemyHit3, EnemyHit4, GOver, Startman;
    public static AudioClip TakeAround,lets, hit1, glass, letsBuy, attack1, attack2, attack3;
    public static AudioClip enemy1, enemy2, enemy3, WIN, atras, alante, DIE, door, burbuja, NEXT, GameOver;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHit1 = Resources.Load<AudioClip>("mnstr5");
        EnemyHit2 = Resources.Load<AudioClip>("mnstr9");
        EnemyHit3 = Resources.Load<AudioClip>("mnstr11");
        Startman = Resources.Load<AudioClip>("HelpYou");
        GOver = Resources.Load<AudioClip>("1yell3");
        TakeAround = Resources.Load<AudioClip>("takealook around");
        lets = Resources.Load<AudioClip>("letstrade");

        hit1 = Resources.Load<AudioClip>("hit1");
        glass = Resources.Load<AudioClip>("Bottle_Break");
        letsBuy = Resources.Load<AudioClip>("buy something");

        attack1 = Resources.Load<AudioClip>("swing"); 
        attack2 = Resources.Load<AudioClip>("Socapex - new_hits");
        attack3 = Resources.Load<AudioClip>("Socapex - big punch");

        enemy1 = Resources.Load<AudioClip>("zombie-5");
        enemy2 = Resources.Load<AudioClip>("zombie-6");
        enemy3 = Resources.Load<AudioClip>("zombie-7");

        WIN = Resources.Load<AudioClip>("Won");
        atras = Resources.Load<AudioClip>("Atras");
        alante = Resources.Load<AudioClip>("Alante");

        DIE = Resources.Load<AudioClip>("Button_DIE");
        door = Resources.Load<AudioClip>("door");
        burbuja = Resources.Load<AudioClip>("bubble3");

        NEXT = Resources.Load<AudioClip>("NextLevel");
        GameOver = Resources.Load<AudioClip>("GameOver");





        audiosrc = GetComponent<AudioSource>();
        audiosrc.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Hit1":
                audiosrc.PlayOneShot(EnemyHit1);
                break;
            case "Hit2":
                audiosrc.PlayOneShot(EnemyHit2);
                break;
            case "Hit3":
                audiosrc.PlayOneShot(EnemyHit3);
                break;
            case "Hit4":
                audiosrc.PlayOneShot(EnemyHit4);
                break;
            case "Dead_Man":
                audiosrc.PlayOneShot(GOver);
                break;
            case "Start_Man":
                audiosrc.PlayOneShot(Startman);
                break;
            case "Around":
                audiosrc.PlayOneShot(TakeAround);
                break;
            case "let":
                audiosrc.PlayOneShot(lets);
                break;
            case "glass":
                audiosrc.PlayOneShot(glass);
                break;
            case "hit":
                audiosrc.PlayOneShot(hit1);
                break;
            case "buy":
                audiosrc.PlayOneShot(letsBuy);
                break;
            case "a1":
                audiosrc.PlayOneShot(attack1);
                break;
            case "a2":
                audiosrc.PlayOneShot(attack2);
                break;
            case "a3":
                audiosrc.PlayOneShot(attack3);
                break;
            case "e1":
                audiosrc.PlayOneShot(enemy1);
                break;
            case "e2":
                audiosrc.PlayOneShot(enemy2);
                break;
            case "e3":
                audiosrc.PlayOneShot(enemy3);
                break;
            case "win":
                audiosrc.PlayOneShot(WIN);
                break;
            case "atras":
                audiosrc.PlayOneShot(atras);
                break;
            case "alante":
                audiosrc.PlayOneShot(alante);
                break;
            case "die":
                audiosrc.PlayOneShot(DIE);
                break;
            case "door":
                audiosrc.PlayOneShot(door);
                break;
            case "heal":
                audiosrc.PlayOneShot(burbuja);
                break;
            case "next":
                audiosrc.PlayOneShot(NEXT);
                break;
            case "GO":
                audiosrc.PlayOneShot(GameOver);
                break;

        }
    }
}
