workspace "QuickStay - C4 L2 Containers" {

    model {
        !identifiers hierarchical

        traveler = person "Traveler" "Customer who searches, books, pays, and manages reservations."
        hotelStaff = person "Hotel Staff" "Front desk and operations staff."

        paymentProvider = softwareSystem "Payment Provider" "External gateway for payment authorization/capture/refunds."
        otaPlatform = softwareSystem "OTA / Travel Agency Platform" "External booking channels."
        notificationProvider = softwareSystem "Notification Provider" "External email/SMS/push provider."

        quickstay = softwareSystem "QuickStay Platform" "Hotel booking platform (monolith in .NET + Next.js front)." {
            webApp = container "Web App" "Customer and simple staff web UI." "Next.js (TS)"{
                tag "Web App"
            }
            bookingApi = container "Booking API" "Single JSON/HTTP API backend." ".NET Web API"{
                tag "Booking API"
            }
            db = container "Database" "Transactional data for hotels, inventory, reservations, and payments." "PostgreSQL"{
                tag "PostgreSQL"
            }
        }

        traveler -> quickstay.webApp "Uses"
        hotelStaff -> quickstay.webApp "Uses (staff mode basic)"

        quickstay.webApp -> quickstay.bookingApi "Calls API" "HTTPS/JSON"
        quickstay.bookingApi -> quickstay.db "Reads/Writes"

        quickstay.bookingApi -> paymentProvider "Payment authorization/capture"
        quickstay.bookingApi -> otaPlatform "Reservation/inventory sync"
        quickstay.bookingApi -> notificationProvider "Sends emails/SMS"
    }

    views {
        container quickstay "Containers" {
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
                colour #1168bd
                stroke #1168bd
            }
            element "Web App" {
                shape WebBrowser
            }
            element "PostgreSQL" {
                shape Cylinder
            }
            element "Booking API" {
                shape Shell
            }
            element "Person" {
                fontSize 22
                shape Person
            }
        }
    }
}