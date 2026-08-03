workspace "QuickStay - C4 L3 Components (.NET Monolith API)" {

    model {
        !identifiers hierarchical

        paymentProvider = softwareSystem "Payment Provider" "External gateway for payment authorization/capture/refunds."
        otaPlatform = softwareSystem "OTA / Travel Agency Platform" "External booking channels."
        notificationProvider = softwareSystem "Notification Provider" "External email/SMS/push provider."

        quickstay = softwareSystem "QuickStay Platform" "Hotel booking platform." {
            webApp = container "Web App" "Customer and staff web UI." "Next.js"

            bookingApi = container "Booking API" "Single JSON/HTTP API backend." ".NET Web API" {
                searchComponent = component "Search Component" "Search hotels/rooms by location, dates, price, amenities." "ASP.NET Core + Application Service"
                availabilityComponent = component "Availability Component" "Calculates real-time availability and temporary holds." "ASP.NET Core + Domain Service"
                reservationComponent = component "Reservation Component" "Create, read, cancel, and modify reservation (basic)." "ASP.NET Core + Application Service"
                paymentComponent = component "Payment Component" "Online payment flow and pay-at-hotel registration." "ASP.NET Core + External Adapter"
                notificationComponent = component "Notification Component" "Booking confirmation/reminder/change notifications." "Background/Service"
            }

            db = container "Database" "Transactional store." "PostgreSQL"{
                tag "PostgreSQL"
            }

            webApp -> bookingApi.searchComponent "Searches"
            webApp -> bookingApi.availabilityComponent "Checks availability"
            webApp -> bookingApi.reservationComponent "Creates/manages reservations"
            webApp -> bookingApi.paymentComponent "Performs payment"

            bookingApi.searchComponent -> bookingApi.availabilityComponent "Queries availability"
            bookingApi.reservationComponent -> bookingApi.availabilityComponent "Places/releases holds"
            bookingApi.reservationComponent -> bookingApi.paymentComponent "Triggers payment when needed"
            bookingApi.reservationComponent -> bookingApi.notificationComponent "Triggers notifications"

            bookingApi.searchComponent -> db "Reads hotels/rooms/rates"
            bookingApi.availabilityComponent -> db "Reads/Writes inventory"
            bookingApi.reservationComponent -> db "Reads/Writes reservations"
            bookingApi.paymentComponent -> db "Reads/Writes payments"
            bookingApi.notificationComponent -> db "Reads templates/logs"


            bookingApi.paymentComponent -> paymentProvider "Calls payment API" "HTTPS"
            bookingApi.notificationComponent -> notificationProvider "Sends messages" "HTTPS"
            bookingApi.reservationComponent -> otaPlatform "Syncs reservation updates" "HTTPS/Webhook"
        }
    }

    views {
        component quickstay.bookingApi "BookingApiComponents" {
            include *
            autolayout lr
        }
        styles {
            relationship "Relationship" {
                thickness 4
                width 300
            }
            element "Element" {
                shape RoundedBox
                strokeWidth 7
            }
            element "PostgreSQL" {
                shape Cylinder
            }
            element "Component" {
                shape Component
            }

        }
        theme default
    }
}