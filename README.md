# Grupo 4 - Instituto educativo

### Integrantes
> - Toloza Affatato, Augusto Cesar	<toloza.augusto@gmail.com>
> - Baltar, Lautaro	<lautaro.baltar@gmail.com>
> - Escobedo, Juan Cruz	<juancruzescobedo@hotmail.com>
> - Forrester, Ignacio	<nachoforrester@gmail.com>

### Idea
Esta aplicación está orientada al manejo básico de un instituto educativo.
 
### Modelos
 - Profesor 
 - Alumno 
 - MateriaCursada 
 - Materia 
 - Calificación 
 - Carrera
 
### Consideraciones mínimas
 - Un Alumno tiene: 
	 - Varias MateriaCursada 
	 - Carrera 
 
 - Una MateriaCursada tiene: 
	 - Alumnos 
	 - Materia 
	 - Nombre 
 
 - Un Profesor tiene: 
	 - un legajo 
	 - Materias que puede aplicar 
 
 - Una Materia  tiene: 
	 - Nombre 
	 - Descripción contenido 
	 - Cupo máximo 
 
 - Una calificación tiene: 
	 - Tipo Parcial/TP/Final 
	 - Relativa insuficiente, suficiente, Bueno, excelente, sobresaliente 
	 - Absoluta 2,4,5,8,… etc. 
 
 - Una Carrera tiene: 
	 - Materias 
 
##### Se requiere que 
 - Se puedan cargar y administrar   
	 - Profesores 
	 - Alumnos 
	 - MateriaCursada 
	 - Materias 
	 - Carreras
 - A los profesores  
	 - Se le pueda seleccionar que materias dan 
 - A los alumnos se les puede  
	 - Asignar una carrera 
	 - Asignar Materias a cursar en el cuatrimestre 
	 - Calificar en las materias que están cursando 
 - A las MateriaCursada 
	 - Abrir una cursada con una materia 
	 - Asignarle un profesor 
	 - Asignarle alumnos hasta el cupo máximo de la materia 
 - Sacar un reporte  
	 - De cursadas por materia, con cantidad de alumnos anotados y cupos disponibles. 
	 - Por alumno, estado de materias en curso y calificaciones 
