/* not mine */

public class P01_BlankReceipt {
    public static void main(String[] args) {
        blankReceipt();
    }

    static void blankReceipt(){
        receiptHeader();
        receiptBody();
        receiptFooter();
    }

    static void receiptHeader(){
        System.out.println("CASH RECEIPT");
        System.out.println("------------------------------");
    }

    static void receiptBody(){
        System.out.println("Charged to____________________");
        System.out.println("Received by___________________");
    }

    static void receiptFooter(){
        System.out.println("------------------------------");
        System.out.println("\u00A9 SoftUni");
    }
}
