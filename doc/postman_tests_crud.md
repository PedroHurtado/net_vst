
# Postman Tests for CRUD Operations on `{id: string, name: string}`

## 1. GET (Obtener todos los elementos o uno específico)

### **URL**: 
- `GET /modelos` (obtener todos)
- `GET /modelos/{id}` (obtener uno específico)

### **Ejemplo de URL**:
- `http://localhost:3000/modelos`
- `http://localhost:3000/modelos/{{id}}`

### **Tests**:

```javascript
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

pm.test("Response is an array or object", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData).to.be.an('object');  // o 'array', depende de tu respuesta
});
```

---

## 2. POST (Crear un nuevo elemento)

### **URL**: 
- `POST /modelos`

### **Ejemplo de URL**:
- `http://localhost:3000/modelos`

### **Body (raw JSON)**:
```json
{
    "name": "Example Name"
}
```

### **Tests**:

```javascript
pm.test("Status code is 201", function () {
    pm.response.to.have.status(201);
});

pm.test("Response has correct ID and Name", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData).to.have.property("id");
    pm.expect(jsonData).to.have.property("name", "Example Name");
});
```

---

## 3. PUT (Actualizar un elemento específico)

### **URL**: 
- `PUT /modelos/{id}`

### **Ejemplo de URL**:
- `http://localhost:3000/modelos/{{id}}`

### **Body (raw JSON)**:
```json
{
    "name": "Updated Name"
}
```

### **Tests**:

```javascript
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

pm.test("Response has updated name", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData).to.have.property("name", "Updated Name");
});
```

---

## 4. DELETE (Eliminar un elemento específico)

### **URL**: 
- `DELETE /modelos/{id}`

### **Ejemplo de URL**:
- `http://localhost:3000/modelos/{{id}}`

### **Tests**:

```javascript
pm.test("Status code is 204", function () {
    pm.response.to.have.status(204);
});

pm.test("Body is empty", function () {
    pm.response.to.be.empty;
});
```

---

## Instrucciones adicionales:

1. **Variables**: Usa variables de entorno en Postman para manejar los `id` y otros datos dinámicos (e.g., `{{id}}`).
2. **Automatización de tests**: Asegúrate de agregar estos tests en cada solicitud para verificar que las respuestas son correctas en todas las operaciones CRUD.
