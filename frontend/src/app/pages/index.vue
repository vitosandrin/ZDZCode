<template>
  <div class="flex justify-center items-center h-screen relative bg-gray-100">
    <CenterButtons @openModal="openModal" />

    <Modal
      v-if="modals.deposit"
      :visible="modals.deposit"
      title="Enviar Depósito"
      placeholder="Valor do Depósito"
      submitText="Enviar"
      submitClass="bg-green-500 text-white hover:bg-green-400"
      @submit="handleDeposit"
      @close-modal="closeModal('deposit')"
    />
    <Modal
      v-if="modals.withdraw"
      :visible="modals.withdraw"
      title="Sacar Dinheiro"
      placeholder="Valor do Saque"
      submitText="Sacar"
      submitClass="bg-red-500 text-white hover:bg-red-400"
      @submit="handleWithdraw"
      @close-modal="closeModal('withdraw')"
    />

    <AccountStatement :transactions="transactions" />
  </div>
</template>

<script>
import CenterButtons from "@/components/CenterButtons.vue";
import Modal from "@/components/Modal.vue";
import AccountStatement from "@/components/AccountStatement.vue";

export default {
  components: {
    CenterButtons,
    Modal,
    AccountStatement,
  },
  data() {
    return {
      modals: {
        deposit: false,
        withdraw: false,
      },
      transactions: [
        { type: "Depósito", amount: 500, date: "2025-01-01" },
        { type: "Saque", amount: 200, date: "2025-01-03" },
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
    handleDeposit(amount) {
      this.transactions.push({
        type: "Depósito",
        amount,
        date: new Date().toISOString().split("T")[0],
      });
      this.closeModal("deposit");
    },
    handleWithdraw(amount) {
      this.transactions.push({
        type: "Saque",
        amount,
        date: new Date().toISOString().split("T")[0],
      });
      this.closeModal("withdraw");
    },
  },
};
</script>
