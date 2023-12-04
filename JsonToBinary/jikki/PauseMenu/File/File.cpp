#include "File.h"
#include"FileManager.h"

File::File(FileManager& manager) :manager_(manager) {

}
File::~File() {
	manager_.Delete();
}
int 
File::GetHandle()const {
	return handle_;
}