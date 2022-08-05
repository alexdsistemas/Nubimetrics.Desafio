# Desafío 2: Crear endpoint “**búsqueda**”:

1. Crear una aplicación del tipo REST Web Api exponer el endpoint que llamaremos
“búsqueda”

El endpoint deberá ser llamado por un parámetro de tipo string. Por Ejemplo Para:

● http://localhost:8080/MyRestfulApp/busqueda/TERMINO
● El término (TERMINO), por ejemplo Iphone, deberá ser lo que se debe buscar. El
endpoint deberá consumir la información del siguiente servicio externo: Resultado de
la api search para el término ‘Iphone’ en Mercado Libre

**Consideraciones:**

● Este endpoint deberá devolver el objeto como lo devuelve el servicio externo.
● En el array “results” solo incluir los Fields:

○ id
○ site_id
○ title
○ price
○ seller.id
○ permalink