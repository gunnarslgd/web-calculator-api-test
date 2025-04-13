# web-calculator-api-test

## Project Overview
This project demonstrates the development of a demo API server as part of a technical interview. The API provides basic calculator functionality, supporting four operations: **addition, subtraction, multiplication, and division** with two numerical inputs.

## Specifications
The original requirement was to develop a web service that performs basic arithmetic operations (**+, -, *, /**) on two numerical arguments. These inputs may be provided in various formats, including **numerical strings, integers, or floating-point numbers**.

For this demo, **double** is used as the input data type to simplify implementation. In a real-world scenario, additional validation and handling would be required to support multiple input formats.

## Considerations for a Live Product
If this were to be deployed as a live product, the following aspects would need to be addressed:

### 🔒 API Authentication & Authorization
- Implement authentication and authorization mechanisms to ensure **secure access**.
- Restrict usage to **authorized users** with appropriate permissions.

### 📊 Logging & Monitoring
- Enable **logging at the API Gateway** to track **HTTP requests**.
- Add **application-level logging** for critical processes to facilitate **troubleshooting** in production.

### ⚡ Scalability & Performance
- For lightweight operations, **AWS API Gateway + Lambda** provides a **serverless solution**.
- For **resource-intensive tasks** (e.g., database access, caching):
  - Introduce **asynchronous processing** (e.g., message queues).
  - Utilize **backend microservices** to handle computations efficiently.

---
🚀 **This project serves as a proof-of-concept and can be expanded further to meet production-level requirements.**
