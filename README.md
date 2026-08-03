# QuickStay Hotel Platform

## Description
A hotel group wants to create a booking platform for its hotels. Customers can search availability, reserve rooms, pay online, check in digitally, request services, and receive promotions.

## Folders structure
```
quickstay/
├─ docs/
│  └─ c4/
│     ├─ 01-system-context.dsl
│     ├─ 02-containers.dsl
│     └─ 03-components-booking-api.dsl
│
├─ backend/
│  ├─ QuickStay.sln
│  │
│  ├─ src/
│  │  ├─ QuickStay.Api/
│  │  │  ├─ Controllers/
│  │  │  │  ├─ HotelsController.cs
│  │  │  │  ├─ AvailabilityController.cs
│  │  │  │  ├─ ReservationsController.cs
│  │  │  │  ├─ PaymentsController.cs
│  │  │  │  └─ AuthController.cs
│  │  │  ├─ Middleware/
│  │  │  │  └─ ExceptionMiddleware.cs
│  │  │  ├─ Program.cs
│  │  │  ├─ appsettings.json
│  │  │  └─ appsettings.Development.json
│  │  │
│  │  ├─ QuickStay.Application/
│  │  │  ├─ Services/
│  │  │  │  ├─ SearchService.cs
│  │  │  │  ├─ AvailabilityService.cs
│  │  │  │  ├─ ReservationService.cs
│  │  │  │  ├─ PaymentService.cs
│  │  │  │  └─ NotificationService.cs
│  │  │  ├─ DTOs/
│  │  │  │  ├─ Requests/
│  │  │  │  └─ Responses/
│  │  │  └─ Interfaces/
│  │  │
│  │  ├─ QuickStay.Domain/
│  │  │  ├─ Entities/
│  │  │  │  ├─ Hotel.cs
│  │  │  │  ├─ Room.cs
│  │  │  │  ├─ Inventory.cs
│  │  │  │  ├─ Reservation.cs
│  │  │  │  ├─ Payment.cs
│  │  │  │  └─ User.cs
│  │  │  ├─ Enums/
│  │  │  └─ Exceptions/
│  │  │
│  │  └─ QuickStay.Infrastructure/
│  │     ├─ Persistence/
│  │     │  ├─ QuickStayDbContext.cs
│  │     │  ├─ Configurations/
│  │     │  └─ Migrations/
│  │     ├─ Repositories/
│  │     │  ├─ HotelRepository.cs
│  │     │  ├─ InventoryRepository.cs
│  │     │  ├─ ReservationRepository.cs
│  │     │  └─ PaymentRepository.cs
│  │     └─ External/
│  │        ├─ PaymentProviderClient.cs
│  │        ├─ OtaClient.cs
│  │        └─ NotificationClient.cs
│  │
│  └─ tests/
│     ├─ QuickStay.Api.Tests/
│     └─ QuickStay.Application.Tests/
│
├─ frontend/
│  ├─ app/
│  │  ├─ page.tsx                        # búsqueda
│  │  ├─ hotels/[id]/page.tsx            # detalle hotel
│  │  ├─ checkout/page.tsx               # reserva/pago
│  │  ├─ reservations/page.tsx           # mis reservas
│  │  ├─ reservations/[id]/page.tsx      # detalle reserva
│  │  └─ login/page.tsx
│  ├─ components/
│  │  ├─ search/
│  │  ├─ availability/
│  │  ├─ reservation/
│  │  ├─ payment/
│  │  └─ ui/
│  ├─ lib/
│  │  ├─ api.ts
│  │  └─ env.ts
│  ├─ types/
│  ├─ public/
│  ├─ next.config.ts
│  ├─ package.json
│  └─ tsconfig.json
│
├─ infra/
│  ├─ docker-compose.yml                 # postgres
│  └─ .env.example
│
├─ .gitignore
├─ README.md
```