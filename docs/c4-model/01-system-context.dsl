workspace "QuickStay - C4 L1 System Context" {

    model {
        !identifiers hierarchical

        traveler = person "Traveler" "Customer who searches, books, pays, and manages reservations."
        hotelStaff = person "Hotel Staff" "Front desk and operations staff."

        paymentProvider = softwareSystem "Payment Provider" "External gateway for payment authorization/capture/refunds."
        otaPlatform = softwareSystem "OTA / Travel Agency Platform" "External booking channels."
        notificationProvider = softwareSystem "Notification Provider" "External email/SMS/push provider."

        quickstay = softwareSystem "QuickStay Platform" "Hotel booking platform"

        traveler -> quickstay "Searches rooms, reserves, pays, and manages reservations"
        hotelStaff -> quickstay "Manages operational reservations"

        quickstay -> paymentProvider "Processes online payments"
        quickstay -> otaPlatform "Syncs reservation/inventory updates"
        quickstay -> notificationProvider "Sends confirmations, reminders and changes"
    }

    views {
        systemContext quickstay "SystemContext" {
            include *
            autolayout lr
        }
        theme default
    }
}