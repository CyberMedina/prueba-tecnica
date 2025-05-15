# Prueba técnica API

Implementé el patrón de capas (`Controllers`, `Services`, `Models`) y programación orientada a objetos para asegurar una estructura clara, reutilizable y fácil de mantener.

## ✅ Funcionalidades

1. Crear una cuenta bancaria con un saldo inicial.
2. Consultar el saldo de la cuenta.
3. Realizar depósitos y retiros, con lógica para validar la disponibilidad de fondos en caso
de retiro.
4. Calcular el saldo final después de una serie de transacciones.

## 🛠️ Tecnologías Utilizadas

- .NET 8
- ASP.NET Core Web API
- C#
- xUnit para pruebas unitarias

---

## 📁 Estructura del Proyecto

```
prueba-tecnica/
├── Controllers/
│   └── CuentasController.cs
├── Models/
│   ├── CuentaBancaria.cs
│   └── Transaccion.cs
├── Services/
│   └── CuentaService.cs
├──Tests/
    └──CuentaServiceTests.cs
├── Program.cs
└── prueba-tecnica.csproj


```

---

## 🚀 Cómo ejecutar el proyecto

### 1. Clonar el repositorio
```bash
git clone https://github.com/CyberMedina/prueba-tecnica.git
cd prueba-tecnica
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Ejecutar la API
```bash
dotnet run --project prueba-tecnica
```

### 4. Probar la API
- Usa Swagger UI para probar los endpoints:
  - `POST /api/cuentas/crear`
  - `GET /api/cuentas/{numeroCuenta}`
  - `POST /api/cuentas/depositar`
  - `POST /api/cuentas/retirar`
  - `GET /api/cuentas/resumen/{numeroCuenta}`

---

## 🧪 Cómo ejecutar las pruebas

### 1. Ir al proyecto de pruebas
```bash
cd Tests
```

### 2. Ejecutar pruebas
```bash
dotnet test
```
## Pruebas realizadas: 
<img src="https://github.com/CyberMedina/prueba-tecnica/blob/master/prueba-tecnica/Assets/prueba_realizada.png?raw=true" width="800">

---

## 📌 Nota
- No se utiliza base de datos; toda la información se almacena en memoria.

---

## ✨ Autor
**Jhonatan Jazmil Medina Aguirre**
