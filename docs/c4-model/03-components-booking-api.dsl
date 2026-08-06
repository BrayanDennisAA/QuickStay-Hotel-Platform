workspace "QuickStay - C4 L3 Components (.NET Monolith API)" {

    model {
        !identifiers hierarchical

        paymentProvider = softwareSystem "Payment Provider" "External gateway for payment authorization/capture/refunds."
        otaPlatform = softwareSystem "OTA / Travel Agency Platform" "External booking channels."
        notificationProvider = softwareSystem "Notification Provider" "External email/SMS/push provider."

        quickstay = softwareSystem "QuickStay Platform" "Hotel booking platform." {
            webApp = container "Web App" "Customer and staff web UI." "Next.js"

            bookingApi = container "Booking API" "Single JSON/HTTP API backend." ".NET Web API" {
                catalogModule = component "Catalog Module" "Hotels and room types management/read model." "ASP.NET Core Module"
                searchModule = component "Search Module" "Search orchestration using catalog + availability." "ASP.NET Core Module"
                availabilityModule = component "Availability Module" "Inventory by date and temporary hold checks." "ASP.NET Core Module"
                reservationsModule = component "Reservations Module" "Create/modify/cancel reservations." "ASP.NET Core Module"
                paymentsModule = component "Payments Module" "Payment processing and payment state." "ASP.NET Core Module"
                notificationsModule = component "Notifications Module" "Booking notifications (confirmation/change/reminder)." "ASP.NET Core Module"
                integrationsModule = component "Integrations Module" "OTA synchronization adapters/webhooks." "ASP.NET Core Module"
            }

            db = container "Database" "Transactional store." "PostgreSQL"{
                tag "PostgreSQL"
            }

            webApp -> bookingApi.searchModule "Searches hotels"
            webApp -> bookingApi.availabilityModule "Checks availability"
            webApp -> bookingApi.reservationsModule "Creates/manages reservations"
            webApp -> bookingApi.paymentsModule "Executes payments"

            bookingApi.searchModule -> bookingApi.catalogModule "Reads hotels/room types"
            bookingApi.searchModule -> bookingApi.availabilityModule "Checks availability"

            bookingApi.reservationsModule -> bookingApi.availabilityModule "Places/releases holds"
            bookingApi.reservationsModule -> bookingApi.paymentsModule "Triggers payment flow"
            bookingApi.reservationsModule -> bookingApi.notificationsModule "Triggers notifications"
            bookingApi.reservationsModule -> bookingApi.integrationsModule "Publishes reservation updates"


            bookingApi.catalogModule -> db "Reads/Writes catalog tables"
            bookingApi.availabilityModule -> db "Reads/Writes inventory tables"
            bookingApi.reservationsModule -> db "Reads/Writes reservation tables"
            bookingApi.paymentsModule -> db "Reads/Writes payment tables"
            bookingApi.notificationsModule -> db "Reads/Writes notification logs/templates"
            bookingApi.integrationsModule -> db "Reads/Writes sync state tables"


            bookingApi.paymentsModule -> paymentProvider "Calls payment API" "HTTPS"
            bookingApi.notificationsModule -> notificationProvider "Sends messages" "HTTPS"
            bookingApi.integrationsModule -> otaPlatform "Syncs OTA updates" "HTTPS/Webhook"
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