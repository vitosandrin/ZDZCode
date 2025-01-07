<template>
  <div class="absolute top-0 right-0 p-6 bg-gray-800 text-white shadow-lg w-80 h-full overflow-y-auto border-l border-gray-600">
    <h3 class="text-xl font-semibold mb-4">Extrato da Conta</h3>
    
    <div class="mb-4">
      <div class="font-semibold text-lg">Saldo: R$ {{ account?.balance.toFixed(2) }}</div>
    </div>

    <div v-for="(transaction, index) in account?.transactions" :key="index" class="mb-4">
      <div class="font-semibold text-lg">{{ transaction.description }} - R$ {{ transaction.amount.toFixed(2) }}</div>
      <div class="text-sm text-gray-400">{{ formatDate(transaction.createdAt) }}</div>
    </div>
  </div>
</template>


<script setup lang="ts">
import { type Account } from "@/types/types";
import { formatDate } from "@/utils/date";

const props = defineProps<{
  account?: Account;
}>();
</script>
