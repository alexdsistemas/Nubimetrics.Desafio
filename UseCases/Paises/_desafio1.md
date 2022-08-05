# Desafío 1: Crear endpoint **“países”**

1. Crear una aplicación del tipo REST Web Api y exponer el endpoint que llamaremos “Países”

Este endpoint deberá ser llamado los parámetros del país. Por Ejemplo:
Para

● http://localhost:8080/MyRestfulApp/Paises/PAIS
● El País (PAIS) debería ser: "AR", "BR", "CO". La totalidad de los sites se pueden
encontrar en la siguiente documentación de mercadolibre: API classified Locations
de Mercado Libre

**Consideraciones:**

● Para los parámetros “BR” y “CO” hacer que el endpoint de una respuesta que sea
“error 401 unauthorized de http”
● Para el parámetro “AR” el endpoint deberá consumir la información del país desde el
servicio externo: API classified Locations de Mercado Libre - Countries: AR