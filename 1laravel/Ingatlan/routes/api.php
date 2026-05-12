<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\IngatlanokController;

Route::get('/ingatlan', [IngatlanokController::class, 'index']);
Route::post('/ingatlan', [IngatlanokController::class, 'store']);
Route::patch('/ingatlan/{id}', [IngatlanokController::class, 'update']);
Route::delete('/ingatlan/{id}', [IngatlanokController::class, 'destroy']);