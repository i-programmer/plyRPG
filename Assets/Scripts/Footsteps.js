
var controller;
var FootStepsFloor        : AudioClip [];     // Таблица звуков просто по террейну.
var FootStepsGrass        : AudioClip [];     // Таблица звуков по траве.
var FootStepsConcrete     : AudioClip [];     // Таблица звуков по бетону.
var FootStepsWood         : AudioClip [];     // Таблица звуков по дереву.
var FootStepsMetal        : AudioClip [];     // Таблица звуков по металлу.
//var FootStepsUntagged     : AudioClip [];     // Таблица звуков без тега.
     
var audioSource : AudioSource;
public var StepTime : float = 0;
private var stepping : boolean = false; // Шагаем? По умолчанию нет.
private var material = "grass";                   // Материал
public var StepVolume : float;         // Громкость
private var old_pos : Vector3;  // Нужно для отслеживания движения еще и от мышки

function Start(){
    old_pos = transform.position;
}

function Update () {
    controller = GameObject.FindGameObjectWithTag("Player").GetComponent(CharacterController);
    var hit : RaycastHit;
    
    if(controller.isGrounded && !stepping){
        if(old_pos != transform.position){
            // расчитываем время шага
            // можно сделать проверку, на бег, ходьбу назад, и так далее.
            // StepTime = 0.5;
            // StepVolume = 0.5;

            WalkSound();
        }

        old_pos = transform.position;
    }
}

function WalkSound(){
    random_step = 0; // Рандомные промежутки времени.
    Step_pitch = Random.Range(0.9,1.1); // Рандомные темб звука.
    stepping = true;
	
    audioSource.pitch = Step_pitch;     // устанавливаем значение тембра.
    audioSource.volume = StepVolume;    // устанавливаем значение громкости.

    if (material == "floor"){
        audioSource.PlayOneShot (FootStepsFloor[Random.Range(0,FootStepsFloor.length)]);        // воспроизводим случайный звук из таблицы Floor.
        yield WaitForSeconds(StepTime + random_step);                
    }
    
    if (material == "grass"){
    audioSource.PlayOneShot (FootStepsGrass[Random.Range(0,FootStepsGrass.length)]);        // воспроизводим случайный звук из таблицы Grass.
	    yield WaitForSeconds(StepTime + random_step);                                      // ждем пока закончится шаг. 
    } 
    if (material == "concrete"){
    audioSource.PlayOneShot (FootStepsConcrete[Random.Range(0,FootStepsConcrete.length)]);  // воспроизводим случайный звук из таблицы Concrete.
	    yield WaitForSeconds(StepTime + random_step);                                      // ждем пока закончится шаг. 
    } 
    if (material == "wood"){
    audioSource.PlayOneShot (FootStepsWood[Random.Range(0,FootStepsWood.length)]);          // воспроизводим случайный звук из таблицы Wood.
	    yield WaitForSeconds(StepTime + random_step);                                      // ждем пока закончится шаг. 
    } 
    if (material == "metal"){
    audioSource.PlayOneShot (FootStepsMetal[Random.Range(0,FootStepsMetal.length)]);        // воспроизводим случайный звук из таблицы Metal.
	    yield WaitForSeconds(StepTime + random_step);                                      // ждем пока закончится шаг. 
    } 

	stepping = false;
}