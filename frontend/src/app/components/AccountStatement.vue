<template>
    <div class="absolute top-0 right-0 p-6 bg-white shadow-lg w-80 h-full overflow-y-auto border-l border-gray-300">
      <h3 class="text-xl font-semibold mb-4">Extrato da Conta</h3>
      <div v-for="(transaction, index) in transactions" :key="index" class="mb-4">
        <div class="font-semibold text-lg">{{ transaction.type }} - R$ {{ transaction.amount.toFixed(2) }}</div>
        <div class="text-sm text-gray-500">{{ transaction.date }}</div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: "AccountStatement",
    props: {
      transactions: { type: Array, required: true },
    },
  };
  </script>
  