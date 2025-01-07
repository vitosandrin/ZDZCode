export interface Transaction {
    id: string;
    amount: number;
    description: string;
    createdAt: string;
}

export interface AccountData {
    accountNumber: string;
    initialDeposit: number;
}

export interface Account {
    id: string;
    accountNumber: string;
    balance: number;
    transactions: Transaction[];
}