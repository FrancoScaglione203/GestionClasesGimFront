# Trabajo Final Programacion 3 Front
Este proyecto es el FrontEnd de una API para gestionar clases de un salon de un gimnasio. El siguiente link corresponde a la parte del back donde se explica mas en detalle la funcionalidad y como esta compuesto. El proyecto del front esta incompleto, falta la View que muestra los alumnos por clase y tambien la que agregar una clase. Tambien tiene errores a la hora de mostrar algunas imagenes

https://github.com/FrancoScaglione203/GestionClasesGim

---
---

## **Views** 

Layout: barra de navegacion

Login: Donde se encuentra el login y un boton para redirigir a la view Register

Register: donde se cargan los datos para registar un nuevo alumno en DB

Perfil: viste del lado alumno donde permite ver y editar los datos del Alumno

Clases: esta viste se puede ver cuando se loguea un alumno, muestra las clases a las cuales esta anotado y las que tiene disponibles para anotarse

ClasesAdmin: esta viste muestra todas las clases, tiene un boton que permite agregar una clase y tambien se puede ver la lista de alumnos por clase

Alumnos: esta vista se encutra del lado admin, basicamente es donde se maneja el ABM de esta entidad

Usuarios: esta vista se encutra del lado admin, donde se maneja el ABM de esta entidad

Home: la primera viste que se ve al loguearse

---
---
## **Especificación de la Arquitectura**
### **Capa Controllers**
En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.


### **Capa DTOS**
En esta capa estan definidos todos los DataTransferObjects.


### **Capa Models**
En esta capa estan definidos todos los models para transferir datos entre el Back y el Front


### **Capa Views**
En estra capa se encuentran todas las vistas


---
---
## **Paquetes Instalados**
![Logo de Mi Proyecto](https://i.imgur.com/t0AjKQW.png)

---
---
## **Mejoras Versiones Futuras**
Debido a la mala administracion del tiempo hay dos views que no pude lograr su funcionalidad, la de ClaseAdmin que luego muestra los alumnos por clase y tambien la view que me permite agregar una clase

---
---

## **Especificación de GIT**​
* Se implento el patron GitFlow. La rama donde se encuentran las versiones finales es Master, la rama principal a partir de la cual se crean ramas es Develop. La nomenclatura para el nombre de las ramas será la sigueinte: Feature/xx-Titulo (donde xx corresponde con el número de historia)
* El título del pull request debe contener el título de la historia tomada.
---
---
## **Autor**​
* Scaglione Franco
---
---
## **Contacto**
franco.scaglione2@gmail.com
