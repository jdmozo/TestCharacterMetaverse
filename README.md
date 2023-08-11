# TestCharacterMetaverse
Este repositorio guarda el proyecto de Unity.

## Especificaciones técnicas
En este `Readme` se especificaran todos los contenidos usados.

### Ejercicio:
> PRUEBA TÉCNICA UNITY
> En esta prueba vamos a evaluar lo siguiente:
>   1. Limpieza de código.
>   2. Uso de patrones de diseño de software.
>   3. Sistemas modulares.
>   4. Sistema de UI.
>   5. Uso de ScriptablesObject.
> 
> La empresa ACME requiere un sistema de autenticación donde deben ingresar mediante un correo y contraseña usando Firebase auth, adicionalmente se debe poder registrar un usuario > dentro la app.(Crear una escena llamada Login)
> 
> Cuando el usuario esté autenticado inmediatamente se debe aparecer una ventana  para ingresar el link del avatar en caso de que no tenga uno asignado en firebase database. Esta > ventana debe contener un botón de guardar el link del avatar, el link debe quedar almacenado en la base de datos con el fin de no mostrar esta ventana si ya tiene un avatar > almacenado.(Crear una escena llamada Game)
> 
> Después de guardar mi avatar  debe aparecer una ventana con 3 botones. Al momento de presionar estos botones se debe ejecutar un baile en el avatar de ready player me.(usar escena > Game)
> 
> VIRTUAL REALITY
> 
> (Opcional) Como punto adicional en la escena de login debe existir un botón de autenticación con Oculus , al momento autenticarse correctamente debe cargar una escena llamada VR, > cuando la escena de VR esté cargada debe descargarse un avatar de ready player me por defecto y cuando finalice la descarga debe aparecer 3 botones flotantes alrededor del avatar, > al momento de presionar cualquier botón con el láser de VR el avatar debe bailar.
> 
> 
> HERRAMIENTAS:
> https://readyplayer.me/es
> https://firebase.google.com/docs/unity/setup?hl=es-419
> https://www.mixamo.com/#/
> https://docs.unity3d.com/Manual/class-ScriptableObject.html
> https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022
> https://docs.unity.com/ugs/en-us/manual/authentication/manual/platform-signin-oculus 


### Requerimientos técnicos
```bash
Versión actual: 0.1.0
Sistemas operativos:
    - Android 5.1 y versiones posteriores.
```
> Unity

La aplicación esta usando actualmente Unity con la versión ```Unity 2021.3.24f1```, con los siguientes paquetes:

```bash
Packages Unity:
    - 2D Sprite 1.0.0
    - Authentication 2.7.2
    - Jetbrains Rider Editor 3.0.24
    - Test Framework 1.1.33
    - TextMeshPro 3.0.6
    - Timeline 1.6.5
    - Unity UI 1.0.0
    - Version Control 2.0.7
    - Visual Scripting 1.8.0
    - Visual Studio Code Editor 1.2.5
    - Visual Studio Editor 2.0.20
```
```bash
Others:
    - LeanTween 2.51
    - Oculues 55.0.0
    - Firebase 11.3.0
    - gITFast 5.0.0
    - Custom Hierarchy for Unity 1.2.0
    - Ready Player Me Core 3.1.1
    - Ready Player Me WebView 1.2.0
```

## License
[MIT](https://choosealicense.com/licenses/mit/)
