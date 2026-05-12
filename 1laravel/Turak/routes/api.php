<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\TurakController;

Route::get('/kategoria/{id}', [TurakController::class, 'show']);
Route::post('/tura', [TurakController::class, 'store']);
Route::patch('/tura/{id}', [TurakController::class, 'update']);