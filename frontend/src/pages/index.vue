<template>
    <div class="flex justify-center items-center h-screen relative bg-gray-100">
  
      <!-- Botões no centro -->
      <div class="text-center">
        <button class="bg-green-500 text-white px-6 py-3 mb-4 rounded-lg shadow-md hover:bg-green-400 transition duration-300" @click="openModal('deposit')">Enviar Depósito</button>
        <button class="bg-red-500 text-white px-6 py-3 rounded-lg shadow-md hover:bg-red-400 transition duration-300" @click="openModal('withdraw')">Sacar Dinheiro</button>
      </div>
  
      <!-- Modal de Depósito -->
      <div v-if="modals.deposit" class="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
        <div class="bg-white p-6 rounded-lg shadow-lg w-96">
          <h2 class="text-xl font-semibold mb-4">Enviar Depósito</h2>
          <input v-model="transactionAmount" type="number" placeholder="Valor do Depósito" class="w-full p-3 border border-gray-300 rounded-lg mb-4 focus:outline-none focus:ring-2 focus:ring-green-500" />
          <div class="flex justify-between">
            <button @click="sendDeposit" class="bg-green-500 text-white px-6 py-2 rounded-lg shadow-md hover:bg-green-400 transition duration-300">Enviar</button>
            <button @click="closeModal('deposit')" class="bg-gray-300 text-gray-700 px-6 py-2 rounded-lg shadow-md hover:bg-gray-200 transition duration-300">Fechar</button>
          </div>
        </div>
      </div>
  
      <!-- Modal de Saque -->
      <div v-if="modals.withdraw" class="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
        <div class="bg-white p-6 rounded-lg shadow-lg w-96">
          <h2 class="text-xl font-semibold mb-4">Sacar Dinheiro</h2>
          <input v-model="transactionAmount" type="number" placeholder="Valor do Saque" class="w-full p-3 border border-gray-300 rounded-lg mb-4 focus:outline-none focus:ring-2 focus:ring-red-500" />
          <div class="flex justify-between">
            <button @click="withdrawMoney" class="bg-red-500 text-white px-6 py-2 rounded-lg shadow-md hover:bg-red-400 transition duration-300">Sacar</button>
            <button @click="closeModal('withdraw')" class="bg-gray-300 text-gray-700 px-6 py-2 rounded-lg shadow-md hover:bg-gray-200 transition duration-300">Fechar</button>
          </div>
        </div>
      </div>
  
      <!-- Extrato da conta (Lateral Direita) -->
      <div class="absolute top-0 right-0 p-6 bg-white shadow-lg w-80 h-full overflow-y-auto border-l border-gray-300">
        <h3 class="text-xl font-semibold mb-4">Extrato da Conta</h3>
        <div v-for="(transaction, index) in transactions" :key="index" class="mb-4">
          <div class="font-semibold text-lg">{{ transaction.type }} - R$ {{ transaction.amount.toFixed(2) }}</div>
          <div class="text-sm text-gray-500">{{ transaction.date }}</div>
        </div>
      </div>
  
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        modals: {
          deposit: false,
          withdraw: false,
        },
        transactionAmount: 0,
        transactions: [
          { type: 'Depósito', amount: 500, date: '2025-01-01' },
          { type: 'Saque', amount: 200, date: '2025-01-03' },
        ],
      };
    },
    methods: {
      openModal(modal) {
        this.modals[modal] = true;
      },
      closeModal(modal) {
        this.modals[modal] = false;
      },
      sendDeposit() {
        this.transactions.push({
          type: 'Depósito',
          amount: this.transactionAmount,
          date: new Date().toISOString().split('T')[0],
        });
        this.closeModal('deposit');
      },
      withdrawMoney() {
        this.transactions.push({
          type: 'Saque',
          amount: this.transactionAmount,
          date: new Date().toISOString().split('T')[0],
        });
        this.closeModal('withdraw');
      },
    },
  };
  </script>
  
  <style scoped>
  /* Tailwind CSS já aplica os estilos necessários */
  </style>
  