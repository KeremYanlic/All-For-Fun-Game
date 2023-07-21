using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerEvents : MonoBehaviour
{
    public static PlayerEvents Instance;

    public delegate void InstantiatePortal(GameObject doorPrefab, GameObject doorPrefabWithPlatform, bool isPortalPlatform, Vector3 doorSpawnPos);
    private InstantiatePortal instantiatePortal;

  
    #region ActionNamePart
    public event Action<PlayerEvents,OnMapChangedEventArgs> OnMapChanged;
    public event Action<PlayerEvents> OnCollideWithTrap;
    public event Action<PlayerEvents, PlayerEventsWallArgs> OnCollideWithWall;
    public event Action<PlayerEvents> OnCollideWithCoin;
    public event Action<PlayerEvents,PlayerEventsBrokenPlatform> OnCollideWithBrokenPlatform;
    public event Action<PlayerEvents> OnCollideWithDoor;
    #endregion
    #region EventClasses
    public class OnMapChangedEventArgs : EventArgs
    {
        public int levelGoldAmount;
        public bool isPortalHasPlatform;
        public Vector3 portalPosition;
        public float brokenPlatformDestroyTime;
    }

    public class PlayerEventsBrokenPlatform : EventArgs
    {
        public GameObject brokenPlatform;
        public float destroyTime;
    }
    public class PlayerEventsDieArgs : EventArgs
    {
        public Vector3 startPosition;
    }
    public class PlayerEventsWallArgs : EventArgs
    {
        public float xValue;
    }
    #endregion

    private int levelGoldAmount;
    private bool isPortalHasPlatform;
    private Vector3 portalPosition;
    private float brokenPlatformDestroyTime;

    private void Awake()
    {
        Instance = this;
    }
   
    private void OnEnable()
    {
        OnMapChanged += PlayerEvents_OnMapChanged;

        OnCollideWithTrap += PlayerEvents_OnCollideWithTrapEvent;
        OnCollideWithWall += PlayerEvents_OnCollideWithWallEvent;
        OnCollideWithCoin += PlayerEvents_OnCollideWithCoinEvent;
        OnCollideWithBrokenPlatform += PlayerEvents_OnCollideWithBrokenPlatform;
        OnCollideWithDoor += PlayerEvents_OnCollideWithPortal;
        
    }
    private void OnDisable()
    {
        OnMapChanged -= PlayerEvents_OnMapChanged;

        OnCollideWithTrap -= PlayerEvents_OnCollideWithTrapEvent;
        OnCollideWithWall -= PlayerEvents_OnCollideWithWallEvent;
        OnCollideWithCoin -= PlayerEvents_OnCollideWithCoinEvent;
        OnCollideWithBrokenPlatform -= PlayerEvents_OnCollideWithBrokenPlatform;
        OnCollideWithDoor -= PlayerEvents_OnCollideWithPortal;
    }


    private void Start()
    {
        instantiatePortal = new InstantiatePortal(InstantiatePortalPrefab);
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            CallOnCollideWithTrap();
            // Instead of resetting player position , we will reset the current episode later.
        }
        if(collision.gameObject.tag == "wall")
        {
            CallOnCollideWithWall(-1);
        }
      
        if (collision.gameObject.tag == "door")
        {
            DestroyObject(collision.gameObject);
            CallOnCollideWithPortal();
            
        }
        if(collision.gameObject.tag == "brokenPlatform")
        {
            CallOnCollideWithBrokenPlatform(collision.gameObject,brokenPlatformDestroyTime);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            CallOnCollideWithCoin();
        }
    }

    // <summary>
    // Calling ON MAP CHANGED EVENT METHOD
    // </summary>

    public void CallOnMapChangedEvent(int levelGoldAmount, bool isPortalHasPlatform, Vector3 portalPosition, float brokenPlatformDestroyTime)
    {
        OnMapChanged?.Invoke(this, new OnMapChangedEventArgs()
        {
            levelGoldAmount = levelGoldAmount,
            isPortalHasPlatform = isPortalHasPlatform,
            portalPosition = portalPosition,
            brokenPlatformDestroyTime = brokenPlatformDestroyTime
        });
    }

    // <summary>
    // ON MAP CHANGED EVENTS
    // </summary>


    private void PlayerEvents_OnMapChanged(PlayerEvents playerEvents, OnMapChangedEventArgs onMapChangedEventArgs)
    {
        levelGoldAmount = onMapChangedEventArgs.levelGoldAmount;
        isPortalHasPlatform = onMapChangedEventArgs.isPortalHasPlatform;
        portalPosition = onMapChangedEventArgs.portalPosition;
        brokenPlatformDestroyTime = onMapChangedEventArgs.brokenPlatformDestroyTime;
    }


    // <summary>
    // A METHOD THAT HAPPEN WHEN YOU COLLIDE WITH A BROKEN PLATFORM 
    // </summary>


    public void CallOnCollideWithBrokenPlatform(GameObject brokenPlatform, float destroyTime)
    {
        OnCollideWithBrokenPlatform?.Invoke(this, new PlayerEventsBrokenPlatform { brokenPlatform = brokenPlatform, destroyTime = destroyTime });
    }

    // <summary>
    // ON COLLIDE WITH BROKEN PLATFORM EVENT
    // </summary>

    private void PlayerEvents_OnCollideWithBrokenPlatform(PlayerEvents playerEvents, PlayerEventsBrokenPlatform playerEventsBrokenPlatform)
    {
        Destroy(playerEventsBrokenPlatform.brokenPlatform, playerEventsBrokenPlatform.destroyTime);
    }

    // <summary>
    // A METHOD THAT HAPPEN WHEN YOU COLLIDE WITH A TRAP
    // </summary>
    public void CallOnCollideWithTrap()
    {
        OnCollideWithTrap?.Invoke(this);
    }

    // <summary>
    // ON COLLIDE WITH TRAP PLATFORM EVENT
    // </summary>

    private void PlayerEvents_OnCollideWithTrapEvent(PlayerEvents playerEvents)
    {
        SceneManagerSonic.Instance.LoadSonicMainMenu();
        //GAMEMONATIZE !!!!
    }

    // <summary>
    // A METHOD THAT HAPPEN WHEN YOU COLLIDE WITH A WALL
    // </summary>

    public void CallOnCollideWithWall(float xValue)
    {
        OnCollideWithWall?.Invoke(this, new PlayerEventsWallArgs { xValue = xValue });
    }

    // <summary>
    // ON COLLIDE WITH WALL PLATFORM EVENT
    // </summary>

    private void PlayerEvents_OnCollideWithWallEvent(PlayerEvents playerEvents, PlayerEventsWallArgs playerEventsWallArgs)
    {
        FlipFace(playerEventsWallArgs);
    }


    // <summary>
    // A METHOD THAT HAPPEN WHEN YOU TAKE A COIN
    // </summary>

    public void CallOnCollideWithCoin()
    {
        OnCollideWithCoin?.Invoke(this);
    }

    // <summary>
    // ON COLLIDE GOLD COIN PLATFORM EVENT
    // </summary>
    private void PlayerEvents_OnCollideWithCoinEvent(PlayerEvents playerEvents)
    {
        if (levelGoldAmount != 1)
        {
            levelGoldAmount--;
        }
        else
        {
            instantiatePortal(SonicGameManager.Instance.GetPortalPrefab(), SonicGameManager.Instance.GetPortalPrefabWithPlatform(), isPortalHasPlatform, portalPosition);
        }

    }

    // <summary>
    // A METHOD THAT HAPPEN WHEN YOU ENTER A PORTAL
    // </summary>

    public void CallOnCollideWithPortal()
    {
        OnCollideWithDoor?.Invoke(this);
    }

    // <summary>
    // ON ENTER PORTAL EVENT
    // </summary>

    private void PlayerEvents_OnCollideWithPortal(PlayerEvents playerEvents)
    {

        int currentLevelIndex = SonicMapIndexManager.Instance.sonicMapIndex;
        currentLevelIndex++;

        SonicGameManager.Instance.BuildMap(currentLevelIndex);

         PlayerPrefs.SetInt("levelReached", currentLevelIndex);

        SonicMapIndexManager.Instance.sonicMapIndex++;

    }

    private void InstantiatePortalPrefab(GameObject portalPrefab,GameObject portalPrefabWithPlatform,bool isPortalHasPlatform,Vector3 portalSpawnPos)
    {
        if (isPortalHasPlatform)
        {
            GameObject portal = Instantiate(portalPrefabWithPlatform,MapBuilder.Instance.GetOtherThingsContainer());
            portal.gameObject.transform.position = portalSpawnPos;
        }
        else
        {
            GameObject portal = Instantiate(portalPrefab, MapBuilder.Instance.GetOtherThingsContainer());
            portal.gameObject.transform.position = portalSpawnPos;
        }
    }

    private void FlipFace(PlayerEventsWallArgs playerEventsWallArgs)
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= playerEventsWallArgs.xValue;
        transform.localScale = localScale;
    }
   private void DestroyObject(GameObject objectToChange)
    {
        GameObject doorPrefab = objectToChange;
        Destroy(doorPrefab.gameObject);
    }

  

}
