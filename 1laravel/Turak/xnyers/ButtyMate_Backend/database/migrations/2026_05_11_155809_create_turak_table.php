<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('turak', function (Blueprint $table) {
            $table->id();
            $table->foreignId('kategoria_id')->constrained('kategoriak')->onDelete('cascade');
            $table->string('leiras');
            $table->date('indulas');
            $table->integer('tav');
            $table->boolean('aktiv')->default(true);
            $table->string('kep');

            
            });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('turak');
    }
};
